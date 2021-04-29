using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Exceptions
{
    [Serializable]
    public class ClientException : Exception
    {
        public ClientException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
