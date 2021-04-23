using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Reservation
{
    public class Booking
    {
        public int BookingNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Travellers { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }    
    }
}
