using AutoMapper;
using HotelBookingWebAPI.Application.Commands.Reservation.AddBooking;
using HotelBookingWebAPI.Application.Commands.Reservation.DeleteBooking;
using HotelBookingWebAPI.Application.Commands.Reservation.UpdateBooking;
using HotelBookingWebAPI.Application.Queries.Reservation.GetBookings;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Reservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
                var result = await _mediator.Send(new AddBooking());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{bookingNumber}")]
        public async Task<IActionResult> Update(BookingRequest bookingUpDate, int bookingNumber)
        {
            try
            {
                var bookingUpDateRequest = _mapper.Map<Booking>(bookingUpDate);
                var result = await _mediator.Send(new UpdateBooking());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{bookingNumber}")]
        public async Task<IActionResult> Delete(int bookingNumber)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBooking());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
