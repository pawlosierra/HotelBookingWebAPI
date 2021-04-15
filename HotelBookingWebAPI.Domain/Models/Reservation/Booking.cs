using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Reservation
{
    public class Booking
    {
        public Client Client { get; set; }
        public Room Room { get; set; }
        public AvailableDate availableDate { get; set; }
    }
}
