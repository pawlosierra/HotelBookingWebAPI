using HotelBookingWebAPI.Infrastructure.Models.Client;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Booking
{
    public class BookingModel
    {
        [JsonProperty(propertyName: "bookingNumber")]
        public string BookingNumber { get; set; }
        
        [JsonProperty(propertyName: "checkIn")]
        public DateTime CheckIn { get; set; }
        
        [JsonProperty(propertyName: "checkOut")]
        public DateTime CheckOut { get; set; }

        [JsonProperty(propertyName: "travellers")]
        public int Travellers { get; set; }

        [JsonProperty(propertyName: "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(propertyName: "roomId")]
        public string RoomId { get; set; }
    }
}
