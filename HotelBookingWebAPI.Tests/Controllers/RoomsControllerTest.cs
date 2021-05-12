using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using HotelBookingWebAPI.Application.Queries.Bookings.GetRooms;
using HotelBookingWebAPI.Controllers;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Infrastructure.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Tests.Controllers
{
    public class RoomsControllerTest
    {
        private readonly CancellationToken _cancellationToken; 
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        private readonly RoomsController _tested;

        public RoomsControllerTest()
        {
            _cancellationToken = default;
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<RoomProfile>());
            _mapper = new Mapper(configuration);

            _tested = new RoomsController(_mapper, _mediatorMock.Object);
        }

        [Fact]
        public async Task Get_Success()
        {
            var expectedResult = _fixture.CreateMany<Room>();

            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetRooms>(), _cancellationToken))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            var result = await _tested.Get();

            _mediatorMock
                .Verify(x => x.Send(It.IsAny<GetRooms>(), _cancellationToken), Times.Once);
            var okresult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<IEnumerable<Room>>(okresult.Value);
            Assert.Equal(expectedResult, response);
        }
    }
}
