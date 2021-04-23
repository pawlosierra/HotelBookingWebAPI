using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Clients.AddClient
{
    public class AddClientHandler : IRequestHandler<AddClient, Client>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(AddClient request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClients();
            var createClientId = CreateClientId(clients, request.Client);
            var client = await _clientRepository.AddClient(request.Client);
            return client;
        }

        private Client CreateClientId(IEnumerable<Client> clients, Client client)
        {
            client.ClientId = clients.LastOrDefault().ClientId + 1;
            return client;
        }
    }
}
