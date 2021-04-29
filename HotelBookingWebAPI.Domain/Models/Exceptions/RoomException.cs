using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Exceptions
{
    public class RoomException : Exception
    {
        public RoomException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
