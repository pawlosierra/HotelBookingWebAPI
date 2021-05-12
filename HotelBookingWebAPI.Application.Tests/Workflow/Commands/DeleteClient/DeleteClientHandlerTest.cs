using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Clients.DeleteClient;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.DeleteClient
{
    public class DeleteClientHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly IFixture _fixture;

        private readonly DeleteClientHandler _handler;

        public DeleteClientHandlerTest()
        {
            _cancellationToken = default;
            _clientRepositoryMock = new Mock<IClientRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new DeleteClientHandler(_clientRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_ClienExist_ShouldDeleteClient()
        {
            var clientId = "f4f02f79-40df-4a56-80f4-c09fa32e3959";

            var expectResultClientExist = true;
            var expectResult = _fixture.Create<Client>();
            expectResult.ClientId = clientId;

            _clientRepositoryMock
                .Setup(c => c.Exists(clientId))
                .ReturnsAsync(expectResultClientExist);

            _clientRepositoryMock
                .Setup(x => x.DeleteClient(clientId))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<HotelBookingWebAPI.
                Application.Commands.Clients.DeleteClient.DeleteClient>();
            request.ClientId = clientId;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _clientRepositoryMock.Verify(c => c.Exists(clientId), Times.Once);
            _clientRepositoryMock.Verify(x => x.DeleteClient(request.ClientId), Times.Once);
        }
    }
}
