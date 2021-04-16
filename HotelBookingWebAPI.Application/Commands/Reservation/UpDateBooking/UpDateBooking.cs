using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Reservation.UpDateBooking
{
    public class UpDateBooking : IRequest<IEnumerable<Booking>> 
    {
        public UpDateBooking(Booking bookingUpDate, int bookingNumber)
        {
            BookingUpDate = bookingUpDate;
            BookingNumber = bookingNumber;
        }

        public Booking BookingUpDate { get; set; }
        public int BookingNumber { get; set; }
    }
}
