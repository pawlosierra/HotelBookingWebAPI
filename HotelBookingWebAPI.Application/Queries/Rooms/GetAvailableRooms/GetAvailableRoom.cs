using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoom : IRequest<IEnumerable<Room>>
    {
        public GetAvailableRoom(string checkIn, string checkOut, decimal priceNight, int roomArea, int peoplePerRoom, int numberOfBeds)
        {
            CheckIn = DateTime.Parse(checkIn);
            CheckOut = DateTime.Parse(checkOut);
            PriceNight = priceNight;
            RoomArea = roomArea;
            PeoplePerRoom = peoplePerRoom;
            NumberOfBeds = numberOfBeds;
        }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal PriceNight { get; set; }
        public int RoomArea { get; set; }
        public int PeoplePerRoom { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
