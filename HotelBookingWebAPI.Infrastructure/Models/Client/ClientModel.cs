using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Models.Client
{
    public class ClientModel
    {
        [JsonProperty(propertyName: "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(propertyName: "passport")]
        public string Passport { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "lastName")]
        public string LastName { get; set; }

        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "cellPhoneNumber")]
        public string CellPhoneNumber { get; set; }
    }
}
