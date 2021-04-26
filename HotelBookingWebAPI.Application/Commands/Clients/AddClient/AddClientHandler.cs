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
    public class AddClientHandler : IRequestHandler<AddClient, ClientValidation>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientValidation> Handle(AddClient request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClients();
            var clientValidation = new ClientValidation();
            if (CreateClientId(clients, request.Client))
            {
                var client = await _clientRepository.AddClient(request.Client);
                clientValidation.Client = request.Client;
                clientValidation.IsValid = true;
                return clientValidation;
            }
            clientValidation.ErrorCode = "CLIENT_ALREADY_EXIST";
            clientValidation.Message = "The customer already exists";
            clientValidation.IsValid = false;
            return clientValidation;
        }

        private bool CreateClientId(IEnumerable<Client> clients, Client clientRequest)
        {
            var clientIsValid = false;
            if (!clients.Any(c => c.Passport == clientRequest.Passport))
            {
                clientIsValid = true;
                clientRequest.ClientId = clients.LastOrDefault().ClientId + 1;
            }
            return clientIsValid;
        }
    }
}
