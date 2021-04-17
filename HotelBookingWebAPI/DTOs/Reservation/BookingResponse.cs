using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingResponse
    {
        public ClientResponse ClientResponse { get; set; }
        public RoomResponse RoomResponse { get; set; }
        public AvailableDateResponse availableDateResponse { get; set; }
        public int BookingNumber { get; set; }
    }
}
