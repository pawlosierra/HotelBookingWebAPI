using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingRequest
    {
        public ClientRequest ClientRequest { get; set; }
        public RoomRequest RoomRequest { get; set; }
        public AvailableDateRequest AvailableDateRequest { get; set; }
    }
    public class ClientRequest
    {
        public string Passport { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
    }
    public class RoomRequest
    {
        public decimal PriceNight { get; set; }
        public int Capacity { get; set; }
    }
    public class AvailableDateRequest
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
