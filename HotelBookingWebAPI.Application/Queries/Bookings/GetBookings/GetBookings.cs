using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetBookings
{
    public class GetBookings : IRequest<IEnumerable<Booking>>
    {
    }
}
