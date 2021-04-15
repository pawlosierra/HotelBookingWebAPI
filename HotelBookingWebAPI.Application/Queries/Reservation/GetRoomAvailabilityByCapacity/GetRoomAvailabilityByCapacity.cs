using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByCapacity
{
    public class GetRoomAvailabilityByCapacity : IRequest<IEnumerable<Room>>
    {
        public GetRoomAvailabilityByCapacity(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; }
    }
}
