using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingRequest
    {
        [Range(typeof(DateTime), "4/16/2021", "5/16/2021", ErrorMessage = "The Check-In for {0} must be between {1} and {2}.")]
        public string CheckIn { get; set; }
        [Range(typeof(DateTime), "4/16/2021", "5/16/2021", ErrorMessage = "The Check-Out for {0} must be between {1} and {2}.")]
        public string CheckOut { get; set; }
        [Range(1, 7, ErrorMessage = "The value for {0} must be between {1} and {2}")]
        public int Travellers { get; set; }
        public ClientRequest ClientRequest { get; set; }
        public RoomRequest RoomRequest { get; set; }
    }
}
