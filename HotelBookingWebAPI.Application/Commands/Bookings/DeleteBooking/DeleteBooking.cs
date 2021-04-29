using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Bookings.DeleteBooking
{
    public class DeleteBooking : IRequest<Booking>
    {
        public DeleteBooking(string bookingNumber)
        {
            BookingNumber = bookingNumber;
        }

        public string BookingNumber { get; set; }
    }
}
