using AutoMapper;
using HotelBookingWebAPI.Application.Commands.Bookings.AddBooking;
using HotelBookingWebAPI.Application.Commands.Bookings.DeleteBooking;
using HotelBookingWebAPI.Application.Commands.Bookings.UpdateBooking;
using HotelBookingWebAPI.Application.Queries.Bookings.GetBookings;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.DTOs.Bookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                var bookings = await _mediator.Send(new GetBookings());
                var result = _mapper.Map<IEnumerable<BookingResponse>>(bookings);
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
                var bookingCreated = await _mediator.Send(new AddBooking(booking));
                var result = _mapper.Map<BookingResponse>(bookingCreated);

                return Ok(result);
            }
            catch (BookingException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BookingError()
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

        [HttpPut("{bookingNumber}")]
        public async Task<IActionResult> Update([Required(ErrorMessage = "The field bookingNumber is required")]
                                                string bookingNumber, BookingUpdateRequest bookingUpDate)
        {
            try
            {
                var bookingUpdateRequest = _mapper.Map<Booking>(bookingUpDate);
                var updatedBooking = await _mediator.Send(new UpdateBooking(bookingUpdateRequest, bookingNumber));
                var result = _mapper.Map<BookingResponse>(updatedBooking);
                return Ok(result);
            }
            catch (BookingException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BookingError()
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

        [HttpDelete("{bookingNumber}")]
        public async Task<IActionResult> Delete([Required(ErrorMessage = "The field bookingNumber is required")]
                                                [Range(10000, 100000, ErrorMessage = "The value for {0} must be between {1} and {2}")]
                                                string bookingNumber)
        {
            try
            {
                var booking = await _mediator.Send(new DeleteBooking(bookingNumber));
                var result = _mapper.Map<BookingResponse>(booking);
                return Ok(result);
            }
            catch(BookingException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BookingError 
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
