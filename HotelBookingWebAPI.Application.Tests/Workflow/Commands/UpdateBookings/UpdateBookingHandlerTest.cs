using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Bookings.UpdateBooking;
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

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.UpdateBookings
{
    public class UpdateBookingHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly IFixture _fixture;

        private readonly UpdateBookingHandler _handler;

        public UpdateBookingHandlerTest()
        {
            _cancellationToken = default;
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new UpdateBookingHandler(_reservationRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_RoomAvailable_ShouldUpdateBooking()
        {
            var roomId = "9";
            var bookingId = "4df48012-c1b3-40c6-88ae-4c622a9ba1a8";
            
            var checkIn = DateTime.Parse("2021-05-25T00:00:00");
            var checkOut = DateTime.Parse("2021-05-27T00:00:00");

            var expectResultBookingExist = true;
            var expectResultIsRoomAvailable = true;
            var expectResult = _fixture.Create<Booking>();
            expectResult.Room.RoomId = roomId;
            expectResult.BookingNumber = bookingId;
            expectResult.CheckIn = checkIn;
            expectResult.CheckOut = checkOut;

            _reservationRepositoryMock
                .Setup(b => b.Exists(bookingId))
                .ReturnsAsync(expectResultBookingExist);

            _reservationRepositoryMock
                .Setup(r => r.IsRoomAvailable(roomId, checkIn, checkOut))
                .ReturnsAsync(expectResultIsRoomAvailable);

            _reservationRepositoryMock
                .Setup(x => x.UpdateBooking(It.IsAny<Booking>()))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<HotelBookingWebAPI.
                Application.Commands.Bookings.UpdateBooking.UpdateBooking>();
            
            request.Booking.Room.RoomId = roomId;
            request.Booking.BookingNumber = bookingId;
            request.BookingNumber = bookingId;
            request.Booking.CheckIn = checkIn;
            request.Booking.CheckOut = checkOut;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _reservationRepositoryMock.Verify(b => b.Exists(bookingId), Times.Once);
            _reservationRepositoryMock.Verify(r => r.IsRoomAvailable(roomId, checkIn, checkOut), Times.Once);
            _reservationRepositoryMock.Verify(x => x.UpdateBooking(request.Booking), Times.Once);
        }
   
        [Fact]
        public async Task Handle_BookingNotExist_ShouldThrowException()
        {
            var bookingId = "4df48012-c1b3-40c6-88ae-4c622a9ba1a8";
            var expectResultBookingExist = false;

            _reservationRepositoryMock
                .Setup(b => b.Exists(bookingId))
                .ReturnsAsync(expectResultBookingExist);

            var request = _fixture.Create<UpdateBooking>();
            request.BookingNumber = bookingId;

            await Assert.ThrowsAsync<BookingException>(() => _handler.Handle(request, _cancellationToken));
        }

        [Fact]
        public async Task Handle_RoomNotAvailable_ShouldThrowException()
        {
            var roomId = "9";
            var checkIn = DateTime.Parse("2021-05-25T00:00:00");
            var checkOut = DateTime.Parse("2021-05-27T00:00:00");

            var expectResultIsRoomAvailable = false;

            _reservationRepositoryMock
                .Setup(r => r.IsRoomAvailable(roomId, checkIn, checkOut))
                .ReturnsAsync(expectResultIsRoomAvailable);

            var request = _fixture.Create<UpdateBooking>();
            request.Booking.Room.RoomId = roomId;
            request.Booking.CheckIn = checkIn;
            request.Booking.CheckOut = checkOut;

            await Assert.ThrowsAsync<BookingException>(() => _handler.Handle(request, _cancellationToken));
        }
    }
}
