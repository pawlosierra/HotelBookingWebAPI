﻿using HotelBookingWebAPI.Infrastructure.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Room
{
    public class RoomModel
    {
        public string RoomId { get; set; }
        public int RoomNumber { get; set; }
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
