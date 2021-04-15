using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Data
{
    public class RoomContext
    {
        private readonly string _path = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Rooms.json";
        public List<RoomModel> DeserializeRoomModel()
        {
            var jsonFile = File.ReadAllText(_path);
            List<RoomModel> rooms = JsonConvert.DeserializeObject<List<RoomModel>>(jsonFile);
            return rooms;
        }
    }
}
