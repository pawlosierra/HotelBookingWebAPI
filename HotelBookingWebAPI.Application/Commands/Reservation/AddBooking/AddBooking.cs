﻿using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Reservation.AddBooking
{
    public class AddBooking : IRequest<Booking>
    {
        public AddBooking(Booking booking)
        {
            Booking = booking;
        }

        public Booking Booking { get; set; }
    }
}
