using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Reservation
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public decimal PriceNight { get; set; }
        public bool Availability { get; set; }
        public int Capacity { get; set; }
        public List<AvailableDate> AvailableDate { get; set; }
    }
}
