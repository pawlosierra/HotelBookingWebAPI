using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Reservation
{
    public class BookingModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int BookingNumber { get; set; }
        public int Travellers { get; set; }
        public ClientModel Client { get; set; }
        public RoomModel Room { get; set; }
        //public AvailableDateModel AvailableDate { get; set; }
        
    }
}
