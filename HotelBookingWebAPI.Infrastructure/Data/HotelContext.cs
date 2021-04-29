using HotelBookingWebAPI.Infrastructure.Models.Client;
using HotelBookingWebAPI.Infrastructure.Models.Booking;
using HotelBookingWebAPI.Infrastructure.Models.Room;
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
        private readonly string _client = @"C:\Users\JuanPawloSierra\source\repos\Projects\HotelBookingWebAPI\HotelBookingWebAPI.Infrastructure\Data\Json\Clients.json";

        public List<ClientModel> DeserializeClientModel()
        {
            var jsonFile = File.ReadAllText(_client);
            List<ClientModel> clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonFile);
            return clients;
        }
        public void serializeClientsModel(IEnumerable<ClientModel> clientModels)
        {
            string clientModelsJson = JsonConvert.SerializeObject(clientModels, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
            File.WriteAllText(_client, clientModelsJson);
        }
        public void serializeClientModel(ClientModel clientModel)
        {
            var clients = DeserializeClientModel();
            clients.Add(clientModel);
            string clientModelJson = JsonConvert.SerializeObject(clients, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            File.WriteAllText(_client, clientModelJson);
        }
        public List<RoomModel> DeserializeRoomModel()
        {
            var jsonFile = File.ReadAllText(_path);
            List<RoomModel> rooms = JsonConvert.DeserializeObject<List<RoomModel>>(jsonFile);
            return rooms;
        }
        public void SerializeRooms(IEnumerable<RoomModel> roomModels)
        {
            string roomModelsJson = JsonConvert.SerializeObject(roomModels, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            File.WriteAllText(_path, roomModelsJson);
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
