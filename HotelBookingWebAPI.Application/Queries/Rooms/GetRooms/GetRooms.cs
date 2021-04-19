using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRooms
{
    public class GetRooms : IRequest<IEnumerable<Room>>
    {
    }
}
