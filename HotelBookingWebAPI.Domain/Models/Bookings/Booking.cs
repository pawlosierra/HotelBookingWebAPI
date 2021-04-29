using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Bookings
{
    public class Booking
    {
        public string BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }    
    }
}
