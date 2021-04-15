using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Reservation
{
    public class RoomModel
    {
        public int RoomNumber { get; set; }
        public decimal PriceNight { get; set; }
        public bool Availability { get; set; }
        public int Capacity { get; set; }
        public List<AvailableDateModel> AvailableDateModel { get; set; }
    }
}
