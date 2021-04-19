using HotelBookingWebAPI.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Room
{
    public class RoomResponse
    {
        public decimal PriceNight { get; set; }
        public int RoomNumber { get; set; }
        public int RoomArea { get; set; }
        public int PeoplePerRoom { get; set; }
        public int NumberOfBeds { get; set; }
        public bool Availability { get; set; }
        public bool OceanView { get; set; }
        public bool FreeWiFi { get; set; }
        public bool AirConditioning { get; set; }
        public bool PetFriendly { get; set; }
        public bool ParkingIncluded { get; set; }
        //public AvailableDateResponse AvailableDate { get; set; }
    }
}
