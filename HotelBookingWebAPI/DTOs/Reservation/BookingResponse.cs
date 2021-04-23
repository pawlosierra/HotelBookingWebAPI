using HotelBookingWebAPI.DTOs.Client;
using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingResponse
    {
        public int BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
    }
}
