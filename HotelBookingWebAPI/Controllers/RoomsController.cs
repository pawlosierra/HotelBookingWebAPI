using AutoMapper;
using HotelBookingWebAPI.Application.Queries.Reservation.GetRooms;
using HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RoomsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetRooms());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet("availability")]
        public async Task<IActionResult> GetAvailableRoom(
                                            [FromQuery(Name = "checkIn")][Required] string checkIn,
                                            [FromQuery(Name = "checkOut")][Required] string checkOut,
                                            [FromQuery(Name = "priceNightMin")] decimal priceNightMin,
                                            [FromQuery(Name = "priceNightMax")] decimal priceNightMax,
                                            [FromQuery(Name = "roomArea")] int roomArea,
                                            [FromQuery(Name = "peoplePerRoom")] int peoplePerRoom,
                                            [FromQuery(Name = "numberOfBeds")] int numberOfBeds)
        {
            try
            {
                var result = await _mediator.Send(new GetAvailableRoom(checkIn, checkOut, priceNightMin, priceNightMax,
                                                                        roomArea, peoplePerRoom, numberOfBeds));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
