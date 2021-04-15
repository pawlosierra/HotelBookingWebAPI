using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class RoomResponse
    {
        public int RoomNumber { get; set; }
        public decimal PriceNight { get; set; }
        public bool Availability { get; set; }
        public int Capacity { get; set; }
    }
}
