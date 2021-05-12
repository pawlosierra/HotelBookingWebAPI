using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Clients.AddClient;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.AddClients
{
    public class AddClientHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly IFixture _fixture;

        private readonly AddClientHandler _handler;
        public AddClientHandlerTest()
        {
            _cancellationToken = default;
            _clientRepositoryMock = new Mock<IClientRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new AddClientHandler(_clientRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_ShouldCreateClient()
        {
            var expectedResult = _fixture.Create<Client>();

            _clientRepositoryMock
                .Setup(x => x.AddClient(It.IsAny<Client>()))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            var request = _fixture.Create<AddClient>();

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectedResult, result);

            _clientRepositoryMock.Verify(x => x.AddClient(request.Client), Times.Once);
        }
    }
}
