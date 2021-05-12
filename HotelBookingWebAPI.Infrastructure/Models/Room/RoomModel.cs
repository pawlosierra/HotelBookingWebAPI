using HotelBookingWebAPI.Infrastructure.Models.Booking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Room
{
    public class RoomModel
    {
        [JsonProperty(propertyName: "roomId")]
        public string RoomId { get; set; }

        [JsonProperty(propertyName: "roomNumber")]
        public int RoomNumber { get; set; }

        [JsonProperty(propertyName: "priceNight")]
        public decimal PriceNight { get; set; }

        [JsonProperty(propertyName: "roomArea")]
        public int RoomArea { get; set; }

        [JsonProperty(propertyName: "peoplePerRoom")]
        public int PeoplePerRoom { get; set; }

        [JsonProperty(propertyName: "numberOfBeds")]
        public int NumberOfBeds { get; set; }

        [JsonProperty(propertyName: "availability")]
        public bool Availability { get; set; }

        [JsonProperty(propertyName: "oceanView")]
        public bool OceanView { get; set; }

        [JsonProperty(propertyName: "freeWiFi")]
        public bool FreeWiFi { get; set; }

        [JsonProperty(propertyName: "airConditioning")]
        public bool AirConditioning { get; set; }

        [JsonProperty(propertyName: "petFriendly")]
        public bool PetFriendly { get; set; }

        [JsonProperty(propertyName: "parkingIncluded")]
        public bool ParkingIncluded { get; set; }
    }
}
