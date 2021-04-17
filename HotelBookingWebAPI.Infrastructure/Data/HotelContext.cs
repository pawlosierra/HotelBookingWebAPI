using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Data
{
    public class HotelContext
    {
        private readonly string _path = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Rooms.json";
        private readonly string _dest = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Bookings.json";
        public List<RoomModel> DeserializeRoomModel()
        {
            var jsonFile = File.ReadAllText(_path);
            List<RoomModel> rooms = JsonConvert.DeserializeObject<List<RoomModel>>(jsonFile);
            return rooms;
        }

        public List<BookingModel> DeserializeBookingModel()
        {
            var jsonFile = File.ReadAllText(_dest);
            List<BookingModel> bookings = JsonConvert.DeserializeObject<List<BookingModel>>(jsonFile);
            return bookings;
        }
        public void SerializeBooking(BookingModel bookingModel)
        {
            var bookings = DeserializeBookingModel();
            bookings.Add(bookingModel);
            string bookingModelJson = JsonConvert.SerializeObject(bookings, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            File.WriteAllText(_dest, bookingModelJson);
        }
        public void SerializeBookings(IEnumerable<BookingModel> bookingModels)
        {
            string bookingModelsJson = JsonConvert.SerializeObject(bookingModels, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
            File.WriteAllText(_dest, bookingModelsJson);
        }
    }
}
