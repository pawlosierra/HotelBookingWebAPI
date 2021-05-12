using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Configurations
{
    public class AppSettings
    {
        public CosmosDb CosmosDb { get; set; }
    }

    public class CosmosDb
    {
        public string Account { get; set; }

        public string Key { get; set; }

        public string DatabaseName { get; set; }

        public string BookingContainerName { get; set; }
        public string ClientContainerName { get; set; }
        public string RoomContainerName { get; set; }
    }
}
