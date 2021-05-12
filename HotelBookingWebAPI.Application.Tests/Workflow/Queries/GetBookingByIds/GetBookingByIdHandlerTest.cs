using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Queries.Bookings.GetBookingById;
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

namespace HotelBookingWebAPI.Application.Tests.Workflow.Queries.GetBookingByIds
{
    public class GetBookingByIdHandlerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly IFixture _fixture;

        private readonly GetBookingByIdHandler _handler;

        public GetBookingByIdHandlerTest()
        {
            _cancellationToken = default;
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _handler = new GetBookingByIdHandler(_reservationRepositoryMock.Object);
        }
        
        [Fact]
        public async Task Handle_BookingExist_RepoReturnBooking_ShouldReturnIt()
        {
            var bookingNumber = "4df48012-c1b3-40c6-88ae-4c622a9ba1a8";

            var expectResultBookingExist = true;
            var expectResult = _fixture.Create<Booking>();
            expectResult.BookingNumber = bookingNumber;

            _reservationRepositoryMock
                .Setup(b => b.Exists(bookingNumber))
                .ReturnsAsync(expectResultBookingExist);

            _reservationRepositoryMock
                .Setup(r => r.GetBookingById(bookingNumber))
                .ReturnsAsync(expectResult);

            var request = _fixture.Create<GetBookingById>();
            request.BookingNumber = bookingNumber;

            var result = await _handler.Handle(request, _cancellationToken);

            Assert.Equal(expectResult, result);

            _reservationRepositoryMock.Verify(b => b.Exists(bookingNumber), Times.Once);
            _reservationRepositoryMock.Verify(x => x.GetBookingById(request.BookingNumber), Times.Once);
        }

        [Fact]
        public async Task Handle_BookingNotExist_ShouldThrowException()
        {
            var expectResultBookingExist = false;
            var expectResult = _fixture.Create<Booking>();
            
            _reservationRepositoryMock
                .Setup(b => b.Exists(expectResult.BookingNumber))
                .ReturnsAsync(expectResultBookingExist);

            var request = _fixture.Create<GetBookingById>();

            await Assert.ThrowsAsync<BookingException>(() => _handler.Handle(request, _cancellationToken));
        }
    }
}
