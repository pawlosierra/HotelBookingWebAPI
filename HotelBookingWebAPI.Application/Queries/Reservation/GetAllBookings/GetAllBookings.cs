using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetAllBookings
{
    public class GetAllBookings : IRequest<IEnumerable<Booking>>
    {
    }
}
