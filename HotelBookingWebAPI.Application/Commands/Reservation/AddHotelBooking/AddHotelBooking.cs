using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Reservation.AddHotelBooking
{
    public class AddHotelBooking : IRequest<Booking>
    {
        public AddHotelBooking(Booking booking)
        {
            Booking = booking;
        }

        public Booking Booking { get; set; }
    }
}
