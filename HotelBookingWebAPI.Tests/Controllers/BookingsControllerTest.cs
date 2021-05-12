using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using HotelBookingWebAPI.Application.Queries.Bookings.GetBookings;
using HotelBookingWebAPI.Controllers;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.DTOs.Bookings;
using HotelBookingWebAPI.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Tests.Controllers
{
    public class BookingsControllerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        private readonly BookingsController _tested;

        public BookingsControllerTest()
        {
            _cancellationToken = default;
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<BookingProfile>());
            _mapper = new Mapper(configuration);

            _tested = new BookingsController(_mapper, _mediatorMock.Object);
        }
        
        [Fact]
        public async Task Get_Success()
        {
            var expectedResult = _fixture.CreateMany<Booking>();

            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetBookings>(), _cancellationToken))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            var result = await _tested.Get();

            _mediatorMock
                .Verify(x => x.Send(It.IsAny<GetBookings>(), _cancellationToken), Times.Once);

            var okresult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<IEnumerable<BookingResponse>>(okresult.Value);

            Assert.Equal(expectedResult.Select(x => x.BookingNumber), response.Select(x => x.BookingNumber));
        }
    }
}
