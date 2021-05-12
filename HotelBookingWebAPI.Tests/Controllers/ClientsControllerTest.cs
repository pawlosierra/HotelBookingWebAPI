using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using HotelBookingWebAPI.Application.Queries.Clients.GetClients;
using HotelBookingWebAPI.Controllers;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Mappers;
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
    public class ClientsControllerTest
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;
        
        private readonly ClientsController _tested; 

        public ClientsControllerTest()
        {
            _cancellationToken = default;
            _mediatorMock = new Mock<IMediator>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ClientProfile>());
            _mapper = new Mapper(configuration);

            _tested = new ClientsController(_mediatorMock.Object, _mapper);
        }

        [Fact]
        public async Task Get_Success()
        {
            var expectedResult = _fixture.CreateMany<Client>();

            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetClients>(), _cancellationToken))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            var result = await _tested.Get(); 

            _mediatorMock
                .Verify(x => x.Send(It.IsAny<GetClients>(), _cancellationToken), Times.Once);

            var okresult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<IEnumerable<Client>>(okresult.Value);
            Assert.Equal(expectedResult, response);
        }
    }
}
