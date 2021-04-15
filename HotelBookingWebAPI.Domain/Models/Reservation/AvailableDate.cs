using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Reservation
{
    public class AvailableDate
    {
        //public AvailableDate(DateTime checkIn, DateTime checkOut)
        //{
        //    CheckIn = checkIn;
        //    CheckOut = checkOut;
        //}

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
