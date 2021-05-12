using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetRoomById
{
    public class GetRoomById : IRequest<Room>
    {
        public GetRoomById(string roomId)
        {
            RoomId = roomId;
        }

        public string RoomId { get; set; }
    }
}
