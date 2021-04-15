using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Reservation
{
    public class BookingModel
    {
        public ClientModel ClientModel { get; set; }
        public RoomModel RoomModel { get; set; }
        public AvailableDateModel availableDateModel { get; set; }
    }
}
