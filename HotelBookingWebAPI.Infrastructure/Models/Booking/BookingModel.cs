using HotelBookingWebAPI.Infrastructure.Models.Client;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Booking
{
    public class BookingModel
    {
        public string BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public string ClientId { get; set; }
        public string RoomId { get; set; }
    }
}
