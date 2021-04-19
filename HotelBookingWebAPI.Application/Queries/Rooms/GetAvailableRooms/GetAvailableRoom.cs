using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoom : IRequest<IEnumerable<Room>>
    {
        public GetAvailableRoom(string checkIn, string checkOut, decimal priceNight, int roomArea, 
                                int peoplePerRoom, int numberOfBeds, bool availability, bool oceanView, 
                                bool freeWiFi, bool airConditioning, bool petFriendly, bool parkingIncluded)
        {
            CheckIn = DateTime.Parse(checkIn);
            CheckOut = DateTime.Parse(checkOut);
            PriceNight = priceNight;
            RoomArea = roomArea;
            PeoplePerRoom = peoplePerRoom;
            NumberOfBeds = numberOfBeds;
            Availability = availability;
            OceanView = oceanView;
            FreeWiFi = freeWiFi;
            AirConditioning = airConditioning;
            PetFriendly = petFriendly;
            ParkingIncluded = parkingIncluded;
        }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal PriceNight { get; set; }
        public int RoomArea { get; set; }
        public int PeoplePerRoom { get; set; }
        public int NumberOfBeds { get; set; }
        public bool Availability { get; set; }
        public bool OceanView { get; set; }
        public bool FreeWiFi { get; set; }
        public bool AirConditioning { get; set; }
        public bool PetFriendly { get; set; }
        public bool ParkingIncluded { get; set; }
    }
}
