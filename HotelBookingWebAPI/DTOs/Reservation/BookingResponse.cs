using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingResponse
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int BookingNumber { get; set; }
        public int Travellers { get; set; }
        public ClientResponse Client { get; set; }
        public RoomResponse Room { get; set; }
    }
}
