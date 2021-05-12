using AutoFixture;
using AutoFixture.AutoMoq;
using HotelBookingWebAPI.Application.Queries.Bookings.GetRooms;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingWebAPI.Application.Tests.Workflow.Queries.GetRoom
{
    public class GetRoomsHandlerTest
    {
        private readonly Mock<IRoomRepository> _roomRepositoryMock;
        private readonly IFixture _fixture;
        public GetRoomsHandlerTest()
        {
            _roomRepositoryMock = new Mock<IRoomRepository>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }
        [Fact]
        public async Task Handle_RepositoryGetResult_ReturnResult()
        {
            var returnedRoom = _fixture.Create<List<Room>>();

            _roomRepositoryMock
                .Setup(x => x.GetRooms())
                .ReturnsAsync(returnedRoom)
                .Verifiable();

            var handler = new GetRoomsHandler(_roomRepositoryMock.Object);

            var request = _fixture.Create<GetRooms>();

            var result = await handler.Handle(request, default(CancellationToken));

            Assert.Equal(returnedRoom, result);

            _roomRepositoryMock.Verify(x => x.GetRooms(), Times.Once);
        }
    }
   
}
