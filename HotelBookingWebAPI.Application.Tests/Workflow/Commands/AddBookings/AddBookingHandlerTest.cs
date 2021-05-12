using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Bookings.AddBooking;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.AddBookings
{
    public class AddBookingHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly IFixture _fixture;

        private readonly AddBookingHandler _handler;
        public AddBookingHandlerTest()
        {
            _cancellationToken = default;
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new AddBookingHandler(_reservationRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_RoomAvailable_ShouldCreateBooking()
        {
            var roomId = "9";
            var checkIn = DateTime.Parse("2021-05-25T00:00:00");
            var checkOut = DateTime.Parse("2021-05-27T00:00:00");
            var expectResultIsRoomAvailable = true;
            var expectResult = _fixture.Create<Booking>();
            expectResult.Room.RoomId = roomId;
            expectResult.CheckIn = checkIn;
            expectResult.CheckOut = checkOut;

            _reservationRepositoryMock
                .Setup(r => r.IsRoomAvailable(roomId, checkIn, checkOut))
                .ReturnsAsync(expectResultIsRoomAvailable);
                
            _reservationRepositoryMock
                .Setup(x => x.AddBooking(It.IsAny<Booking>()))
                .ReturnsAsync(expectResult)
                .Verifiable();

            var request = _fixture.Create<AddBooking>();

            request.Booking.Room.RoomId = roomId;
            request.Booking.CheckIn = checkIn;
            request.Booking.CheckOut = checkOut;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _reservationRepositoryMock.Verify(r => r.IsRoomAvailable(roomId, checkIn, checkOut), Times.Once);
            _reservationRepositoryMock.Verify(x => x.AddBooking(request.Booking), Times.Once);
        }

        [Fact]
        public async Task Handle_RoomNotAvailable_ShouldThrowException()
        {
            var roomId = "9";
            var checkIn = DateTime.Parse("2021-05-25T00:00:00");
            var checkOut = DateTime.Parse("2021-05-27T00:00:00");
            var expectResultIsRoomAvailable = false;
            //var expectResult = _fixture.Create<Booking>();
            
            _reservationRepositoryMock
              .Setup(r => r.IsRoomAvailable(roomId, checkIn, checkOut))
              .ReturnsAsync(expectResultIsRoomAvailable);
            
            var request = _fixture.Create<AddBooking>();
            request.Booking.Room.RoomId = roomId;
            request.Booking.CheckIn = checkIn;
            request.Booking.CheckOut = checkOut;

            await Assert.ThrowsAsync<BookingException>(() => _handler.Handle(request, _cancellationToken));
        }
    }
}
