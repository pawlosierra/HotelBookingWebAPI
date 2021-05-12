using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Clients.UpdateClient;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.UpdateClients
{
    public class UpdateClientHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly IFixture _fixture;

        private readonly UpdateClientHandler _handler;

        public UpdateClientHandlerTest()
        {
            _cancellationToken = default;
            _clientRepositoryMock = new Mock<IClientRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new UpdateClientHandler(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task Handler_ClientExist_ShouldUpdateClient()
        {
            var clientId = "f4f02f79-40df-4a56-80f4-c09fa32e3959";
            var expectResultClientExist = true;
            var expectResult = _fixture.Create<Client>();
            expectResult.ClientId = clientId;

            _clientRepositoryMock
                .Setup(c => c.Exists(clientId))
                .ReturnsAsync(expectResultClientExist);

            _clientRepositoryMock
                .Setup(x => x.UpdateClient(It.IsAny<Client>()))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<UpdateClient>();

            request.ClientId = clientId;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _clientRepositoryMock.Verify(c => c.Exists(clientId), Times.Once);
            _clientRepositoryMock.Verify(x => x.UpdateClient(request.Client), Times.Once);
        }

        [Fact]
        public async Task Handler_ClientNotExist_ShouldThrowException()
        {         
            var expectResultClientExist = false;
            var expectResult = _fixture.Create<Client>();

            _clientRepositoryMock
                .Setup(c => c.Exists(expectResult.ClientId))
                .ReturnsAsync(expectResultClientExist);

            var request = _fixture.Create<UpdateClient>();

            await Assert.ThrowsAsync<ClientException>(() => _handler.Handle(request, _cancellationToken));
        }
    }
}
