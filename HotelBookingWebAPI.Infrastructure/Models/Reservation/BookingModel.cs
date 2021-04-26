using HotelBookingWebAPI.Infrastructure.Models.Client;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Reservation
{
    public class BookingModel
    {
        public int BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
    }
}
