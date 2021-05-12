using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetBookingById
{
    public class GetBookingById : IRequest<Booking>
    {
        public GetBookingById(string bookingNumber)
        {
            BookingNumber = bookingNumber;
        }

        public string BookingNumber { get; set; }
    }
}
