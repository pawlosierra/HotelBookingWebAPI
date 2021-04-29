using HotelBookingWebAPI.DTOs.Client;
using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Bookings
{
    public class BookingResponse
    {
        public string BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public string ClientId { get; set; }
        public string RoomId { get; set; }
    }
}
