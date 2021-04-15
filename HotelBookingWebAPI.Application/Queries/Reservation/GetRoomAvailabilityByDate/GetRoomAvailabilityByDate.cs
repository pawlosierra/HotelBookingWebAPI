using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByDate
{
    public class GetRoomAvailabilityByDate : IRequest<IEnumerable<Room>>
    {
        public DateTime DateOfEntry;

        public GetRoomAvailabilityByDate(string dateOfEntry)
        {
            DateOfEntry = DateTime.Parse(dateOfEntry);
        }
    }
}
