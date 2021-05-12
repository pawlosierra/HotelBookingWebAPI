using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Queries.Clients.GetClientById;
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

namespace HotelBookingWebAPI.Application.Tests.Workflow.Queries.GetClientByIds
{
    public class GetClientByIdHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly IFixture _fixture;

        private readonly GetClientByIdHandler _handler;

        public GetClientByIdHandlerTest()
        {
            _cancellationToken = default;
            _clientRepositoryMock = new Mock<IClientRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new GetClientByIdHandler(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ClientExist_RepoReturnClient_ShouldReturnIt()
        {
            var clientId = "f4f02f79-40df-4a56-80f4-c09fa32e3959";

            var expectResultClientExist = true;
            var expectResult = _fixture.Create<Client>();
            expectResult.ClientId = clientId;

            _clientRepositoryMock
                .Setup(c => c.Exists(clientId))
                .ReturnsAsync(expectResultClientExist);

            _clientRepositoryMock
                .Setup(x => x.GetClientById(clientId))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<GetClientById>();
            request.ClientId = clientId;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _clientRepositoryMock.Verify(c => c.GetClientById(clientId), Times.Once);
            _clientRepositoryMock.Verify(x => x.GetClientById(request.ClientId), Times.Once);
        }

        [Fact]
        public async Task Handle_ClientNotExist_ShouldThrowException()
        {
            var expectResultClientExist = false;
            var expectResult = _fixture.Create<Client>();

            _clientRepositoryMock
                .Setup(c => c.Exists(expectResult.ClientId))
                .ReturnsAsync(expectResultClientExist);

            var request = _fixture.Create<GetClientById>();

            await Assert.ThrowsAsync<ClientException>(() => _handler.Handle(request, _cancellationToken));
        }
    }
}
