﻿using AutoMapper;
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
                                            [FromQuery(Name = "priceNight")] decimal priceNight,
                                            [FromQuery(Name = "roomArea")] int roomArea,
                                            [FromQuery(Name = "peoplePerRoom")] int peoplePerRoom,
                                            [FromQuery(Name = "numberOfBeds")] int numberOfBeds,
                                            [FromQuery(Name = "availability")] bool availability,
                                            [FromQuery(Name = "oceanView")] bool oceanView,
                                            [FromQuery(Name = "freeWiFi")] bool freeWiFi,
                                            [FromQuery(Name = "airConditioning")] bool airConditioning,
                                            [FromQuery(Name = "petFriendly")] bool petFriendly,
                                            [FromQuery(Name = "parkingIncluded")] bool parkingIncluded)
        {
            try
            {
                var result = await _mediator.Send(new GetAvailableRoom(checkIn, checkOut, priceNight, roomArea,
                                                                        peoplePerRoom, numberOfBeds, availability,oceanView, 
                                                                        freeWiFi, airConditioning, petFriendly, parkingIncluded));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
