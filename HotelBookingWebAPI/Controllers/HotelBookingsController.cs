using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HotelBookingWebAPI.Application.Commands.Reservation.AddHotelBooking;
using HotelBookingWebAPI.Application.Queries.Reservation.GetAllRooms;
using HotelBookingWebAPI.Application.Queries.Reservation.GetAllRoomsAvailability;
using HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByCapacity;
using HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByDate;
using HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByPrice;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Reservation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public HotelBookingsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("getAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var result = await _mediator.Send(new GetAllRooms());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getAllRoomAvailability")]
        public async Task<IActionResult> GetAllRoomAvailability()
        {
            try
            {
                var result = await _mediator.Send(new GetAllRoomsAvailability());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getRoomAvailabilityByDate")]
        public async Task<IActionResult> GetRoomAvailabilityByDate(
                                        [FromQuery(Name = "dateOfEntry")]
                                        [Required(ErrorMessage = "The field dateOfEntry is required.")]
                                        [RegularExpression(@"\b(?<mm>\d{1,2})/(?<dd>\d{1,2})/(?<yyyy>\d{4})\b", ErrorMessage = "Invalid date format. Requested format is MM/DD/YYYY")]
                                        string dateOfEntry)
        {
            try
            {
                var result = await _mediator.Send(new GetRoomAvailabilityByDate(dateOfEntry));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getRoomAvailabilityByCapacity")]
        public async Task<IActionResult> GetRoomAvailabilityByCapacity(
                                        [FromQuery(Name = "capacity")]
                                        [Required(ErrorMessage = "The field capacity is required")]
                                        int capacity)
        {
            try
            {
                var result = await _mediator.Send(new GetRoomAvailabilityByCapacity(capacity));
                return Ok(result);
            }
            catch ( Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getRoomAvailabilityByPrice")]
        public async Task<IActionResult> GetRoomAvailabilityByPrice(
                                       [FromQuery(Name = "price")]
                                        [Required(ErrorMessage = "The field price is required")]
                                        decimal price)
        {
            try
            {
                var result = await _mediator.Send(new GetRoomAvailabilityByPrice(price));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("addHotelBooking")]
        public async Task<IActionResult> AddHotelBooking(BookingRequest bookingRequest)
        {
            try
            {
                var booking = _mapper.Map<Booking>(bookingRequest);
                var result = await _mediator.Send(new AddHotelBooking(booking));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
