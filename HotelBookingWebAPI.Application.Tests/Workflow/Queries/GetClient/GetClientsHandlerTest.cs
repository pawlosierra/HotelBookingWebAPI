using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Queries.Clients.GetClients;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Queries.GetClient
{
    public class GetClientsHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly IFixture _fixture;

        private readonly GetClientsHandler _handler;
        public GetClientsHandlerTest()
        {
            _cancellationToken = default;
            _clientRepositoryMock = new Mock<IClientRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new GetClientsHandler(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_RepositoryGetResult_ReturnResult()
        {
            var returnedClients = _fixture.Create<List<Client>>();

            _clientRepositoryMock
                .Setup(x => x.GetClients())
                .ReturnsAsync(returnedClients)
                .Verifiable();

            var request = _fixture.Create<GetClients>();

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(returnedClients, result);

            _clientRepositoryMock.Verify(x => x.GetClients(), Times.Once);
        }
    }
}
