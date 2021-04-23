using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Reservation.UpdateBooking
{
    public class UpdateBooking : IRequest<BookingValidation> 
    {
        public UpdateBooking(Booking booking, int bookingNumber)
        {
            Booking = booking;
            BookingNumber = bookingNumber;
        }

        public Booking Booking { get; set; }
        public int BookingNumber { get; set; }
    }
}
