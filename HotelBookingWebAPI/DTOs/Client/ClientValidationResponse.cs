using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Client
{
    public class ClientValidationResponse
    {
        public ClientResponse ClientResponse { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}
