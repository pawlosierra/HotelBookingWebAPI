using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingValidatioResponse
    {
        public BookingResponse BookingResponse { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}
