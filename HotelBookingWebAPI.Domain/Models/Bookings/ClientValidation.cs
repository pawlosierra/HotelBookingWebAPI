using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Bookings
{
    public class ClientValidation
    {
        public Client Client { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}
