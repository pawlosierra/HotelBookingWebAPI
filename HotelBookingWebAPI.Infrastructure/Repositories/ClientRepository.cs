using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HotelContext _hotelContext;
        private readonly IMapper _mapper;

        public ClientRepository(IMapper mapper)
        {
            _hotelContext = new HotelContext();
            _mapper = mapper;
        }
        public Task<IEnumerable<Client>> GetClients()
        {
            return Task.Run(() =>
            {
                var clients = _hotelContext.DeserializeClientModel();
                return _mapper.Map<IEnumerable<Client>>(clients);
            });
        }
        public Task<Client> AddClient(Client client)
        {
            return Task.Run(() => 
            {
                var clientModel = _mapper.Map<ClientModel>(client);
                clientModel.ClientId = Guid.NewGuid().ToString();
                _hotelContext.serializeClientModel(clientModel);
                var clientCreated = _mapper.Map<Client>(clientModel);
                return clientCreated;
            });
        }

        public Task<Client> UpdateClient(Client clientRequest)
        {
            return Task.Run(() =>
            {
                var clients = _hotelContext.DeserializeClientModel();
                foreach (var client in clients)
                {
                    if (client.ClientId == clientRequest.ClientId)
                    {
                        client.Name = clientRequest.Name;
                        client.LastName = clientRequest.LastName;
                        client.Passport = clientRequest.Passport;
                        client.Email = clientRequest.Email;
                        client.CellPhoneNumber = clientRequest.CellPhoneNumber;
                    }
                }
                _hotelContext.serializeClientsModel(clients);
                return clientRequest;
            });
        }

        public Task<Client> DeleteClient(string bookingNumber)
        {
            return Task.Run(() => 
            {
                var clients = _hotelContext.DeserializeClientModel();
                var deletedClient = clients.Where(c => c.ClientId == bookingNumber).FirstOrDefault();
                var upgradedClients = clients.Where(c => c.ClientId != bookingNumber);
                _hotelContext.serializeClientsModel(upgradedClients);
                return _mapper.Map<Client>(deletedClient);
            });
        }

        public Task<bool> Exists(string bookingNumber)
        {
            return Task.Run(() =>
            {
                var clients = _hotelContext.DeserializeClientModel();
                if (clients.Any(c => c.ClientId == bookingNumber))
                {
                    return true;
                }
                return false;
            });

        }
    }
}
