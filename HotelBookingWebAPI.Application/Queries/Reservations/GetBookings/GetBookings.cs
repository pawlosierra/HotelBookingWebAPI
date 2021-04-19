using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservations.GetBookings
{
    public class GetBookings : IRequest<IEnumerable<Booking>>
    {
    }
}
