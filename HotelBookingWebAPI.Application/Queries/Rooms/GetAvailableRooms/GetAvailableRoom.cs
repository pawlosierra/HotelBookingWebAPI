using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoom : IRequest<IEnumerable<Room>>
    {
        public GetAvailableRoom(string checkIn, string checkOut, decimal priceNightMin, decimal priceNightMax, int roomArea, int peoplePerRoom, int numberOfBeds)
        {
            CheckIn = DateTime.Parse(checkIn);
            CheckOut = DateTime.Parse(checkOut);
            PriceNightMin = priceNightMin;
            PriceNightMax = priceNightMax;
            RoomArea = roomArea;
            PeoplePerRoom = peoplePerRoom;
            NumberOfBeds = numberOfBeds;
        }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal PriceNightMin { get; set; }
        public decimal PriceNightMax { get; set; }
        public int RoomArea { get; set; }
        public int PeoplePerRoom { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
