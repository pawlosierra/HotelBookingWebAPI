using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Reservation
{
    public class Booking
    {
        //public Booking()
        //{
        //    BookingNumber = new Random().Next(10000, 100000);
        //}
        public Client Client { get; set; }
        public Room Room { get; set; }
        public AvailableDate availableDate { get; set; }
        public int BookingNumber { get; set; }
    }
}
