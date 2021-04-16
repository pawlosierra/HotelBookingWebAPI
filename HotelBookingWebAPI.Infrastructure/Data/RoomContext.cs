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
    public class RoomContext
    {
        private readonly string _path = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Rooms.json";
        private readonly string _dest = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Booking.json";
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
            //UpDateRoomMode(bookingModel);
        }
        public void SerializeBookings(IEnumerable<BookingModel> bookingModels)
        {
            string bookingModelsJson = JsonConvert.SerializeObject(bookingModels, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
            File.WriteAllText(_dest, bookingModelsJson);
        }
        //public void UpDateRoomMode(BookingModel bookingModel)
        //{
        //    var roomsUpDate = new List<RoomModel>();
        //    var roomUpDate = new RoomModel();
        //    var jsonFile = File.ReadAllText(_path);
        //    List<RoomModel> rooms = JsonConvert.DeserializeObject<List<RoomModel>>(jsonFile);
        //    foreach (var room in rooms)
        //    {
        //        roomUpDate.RoomNumber = room.RoomNumber;
        //        roomUpDate.PriceNight = room.PriceNight;
        //        roomUpDate.Availability = room.Availability;
        //        roomUpDate.Capacity = room.Capacity;
        //        if (room.RoomNumber == bookingModel.RoomModel.RoomNumber && room.AvailableDateModel.)
        //        {

        //        }
        //    }
        //    string roomModelJson = JsonConvert.SerializeObject(rooms, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        //    File.WriteAllText(_path, roomModelJson);
        //}
    }
}
