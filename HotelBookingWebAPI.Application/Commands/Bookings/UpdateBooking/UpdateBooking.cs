using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Bookings.UpdateBooking
{
    public class UpdateBooking : IRequest<Booking> 
    {
        public UpdateBooking(Booking booking, string bookingNumber)
        {
            Booking = booking;
            BookingNumber = bookingNumber;
        }

        public Booking Booking { get; set; }
        public string BookingNumber { get; set; }
    }
}
