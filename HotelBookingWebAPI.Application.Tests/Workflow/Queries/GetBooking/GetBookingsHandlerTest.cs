using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Queries.Bookings.GetBookings;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Queries.GetBooking
{
    public class GetBookingsHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly IFixture _fixture;

        private readonly GetBookingsHandler _handler;
        public GetBookingsHandlerTest()
        {
            _cancellationToken = default;
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new GetBookingsHandler(_reservationRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_RepoSendListOfBooking_ReturnsAllElement()
        {
            var returnedBookings = _fixture.Create<List<Booking>>();

            _reservationRepositoryMock
                .Setup(x => x.GetBookings())
                .ReturnsAsync(returnedBookings)
                .Verifiable();

            var request = _fixture.Create<GetBookings>();

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(returnedBookings, result);

            _reservationRepositoryMock.Verify(x => x.GetBookings(), Times.Once);
        }
    }
}
