using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Client;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = _hotelContext.DeserializeClientModel();
            return _mapper.Map<IEnumerable<Client>>(clients);
        }
        public async Task<Client> AddClient(Client client)
        {
            var clientModel = _mapper.Map<ClientModel>(client);
            _hotelContext.serializeClientModel(clientModel);
            return client;
        }
    }
}
