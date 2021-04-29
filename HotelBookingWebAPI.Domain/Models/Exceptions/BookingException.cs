using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Domain.Models.Exceptions
{
    [Serializable]
    public class BookingException : Exception
    {
        public BookingException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
