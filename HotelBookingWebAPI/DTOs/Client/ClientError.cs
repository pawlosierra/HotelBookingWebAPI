using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Client
{
    public class ClientError
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
