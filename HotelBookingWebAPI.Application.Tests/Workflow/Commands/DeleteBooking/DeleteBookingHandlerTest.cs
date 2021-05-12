using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Commands.Bookings.DeleteBooking;
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

namespace HotelBookingWebAPI.Application.Tests.Workflow.Commands.DeleteBooking
{
    public class DeleteBookingHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly IFixture _fixture;

        private readonly DeleteBookingHandler _handler;

        public DeleteBookingHandlerTest()
        {
            _cancellationToken = default;
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new DeleteBookingHandler(_reservationRepositoryMock.Object);
        }
        [Fact]
        public async Task Handle_BookingExist_ShouldDeleteBooking()
        {
            var bookingId = "4df48012-c1b3-40c6-88ae-4c622a9ba1a8";
            
            var expectResultBookingExist = true;
            var expectResult = _fixture.Create<Booking>();
            expectResult.BookingNumber = bookingId;

            _reservationRepositoryMock
                .Setup(r => r.Exists(bookingId))
                .ReturnsAsync(expectResultBookingExist);

            _reservationRepositoryMock
                .Setup(x => x.DeleteBooking(bookingId))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<HotelBookingWebAPI.
                Application.Commands.Bookings.DeleteBooking.DeleteBooking>();
            request.BookingNumber = bookingId;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _reservationRepositoryMock.Verify(b => b.Exists(bookingId), Times.Once);
            _reservationRepositoryMock.Verify(x => x.DeleteBooking(request.BookingNumber), Times.Once);
        }

        [Fact]
        public async Task Handle_BookingNotExist_ShouldThrowExceptions()
        {
            var bookingId = "4df48012-c1b3-40c6-88ae-4c622a9ba1a8";

            var expectResultBookingExist = false;
            var expectResult = _fixture.Create<Booking>();
            expectResult.BookingNumber = bookingId;

            _reservationRepositoryMock
                .Setup(r => r.Exists(bookingId))
                .ReturnsAsync(expectResultBookingExist);

            var request = _fixture.Create<HotelBookingWebAPI.
                Application.Commands.Bookings.DeleteBooking.DeleteBooking>();
            request.BookingNumber = bookingId;

            await Assert.ThrowsAsync<BookingException>(
                () => _handler.Handle(request, _cancellationToken));
        }
    }
}
