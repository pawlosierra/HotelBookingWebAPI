using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetAllRoomsAvailability
{
    public class GetAllRoomsAvailability : IRequest<IEnumerable<Room>>
    {
    }
}
