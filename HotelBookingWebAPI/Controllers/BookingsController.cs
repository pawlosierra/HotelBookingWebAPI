using AutoMapper;
using HotelBookingWebAPI.Application.Commands.Reservation.AddBooking;
using HotelBookingWebAPI.Application.Commands.Reservation.DeleteBooking;
using HotelBookingWebAPI.Application.Commands.Reservation.UpdateBooking;
using HotelBookingWebAPI.Application.Queries.Reservations.GetBookings;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Reservation;
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
    public class BookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BookingsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetBookings());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHotelBooking(BookingRequest bookingRequest)
        {
            try
            {
                var booking = _mapper.Map<Booking>(bookingRequest);
                var result = await _mediator.Send(new AddBooking(booking));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookingRequest bookingUpDate, 
                                                [FromQuery(Name = "bookingNumber")]
                                                [Required(ErrorMessage = "The field bookingNumber is required")]
                                                [Range(10000, 100000, ErrorMessage = "The value for {0} must be between {1} and {2}")]
                                                int bookingNumber)
        {
            try
            {
                var bookingUpdateRequest = _mapper.Map<Booking>(bookingUpDate);
                var result = await _mediator.Send(new UpdateBooking(bookingUpdateRequest, bookingNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery(Name = "bookingNumber")]
                                                [Required(ErrorMessage = "The field bookingNumber is required")]
                                                [Range(10000, 100000, ErrorMessage = "The value for {0} must be between {1} and {2}")]
                                                int bookingNumber)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBooking(bookingNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
