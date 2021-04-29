using AutoMapper;
using HotelBookingWebAPI.Application.Queries.Bookings.GetRooms;
using HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.DTOs.Room;
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
                                            [Required(ErrorMessage ="The field CheckIn is required")]
                                            [FromQuery(Name = "checkIn")]
                                            [RegularExpression(@"^(19|20)\d\d-(0[1-9]|1[012])-([012]\d|3[01])T([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$", ErrorMessage = "Invalid date format. Requested format is: YYYY-MM-DDTHH:MM:SS")]
                                            string checkIn,
                                            [Required(ErrorMessage ="The field CheckOut is required")]
                                            [FromQuery(Name = "checkOut")]
                                            [RegularExpression(@"^(19|20)\d\d-(0[1-9]|1[012])-([012]\d|3[01])T([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$", ErrorMessage = "Invalid date format. Requested format is: YYYY-MM-DDTHH:MM:SS")]
                                            string checkOut,
                                            [FromQuery(Name = "priceNightMin")] decimal priceNightMin,
                                            [FromQuery(Name = "priceNightMax")] decimal priceNightMax,
                                            [FromQuery(Name = "roomArea")] int roomArea,
                                            [FromQuery(Name = "peoplePerRoom")] int peoplePerRoom,
                                            [FromQuery(Name = "numberOfBeds")] int numberOfBeds)
        {
            try
            {
                var result = await _mediator.Send(new GetAvailableRooms(checkIn, checkOut, priceNightMin, priceNightMax,
                                                                        roomArea, peoplePerRoom, numberOfBeds));
                return Ok(result);
            }
            catch(RoomException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new RoomError() 
                {
                    ErrorCode = ex.ErrorCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
