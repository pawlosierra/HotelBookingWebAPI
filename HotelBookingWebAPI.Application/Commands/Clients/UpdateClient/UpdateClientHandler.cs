using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Clients.UpdateClient
{
    public class UpdateClientHandler : IRequestHandler<UpdateClient, ClientValidation>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientValidation> Handle(UpdateClient request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClients();
            var clientValidation = new ClientValidation();
            if (clients.Any(c => c.ClientId == request.ClientId))
            {
                var updateClients = UpdateClient(clients, request.Client, request.ClientId);
                await _clientRepository.UpdateClients(updateClients);
                clientValidation = new ClientValidation
                {
                    Client = new Client
                    {
                        ClientId = request.ClientId,
                        Passport = request.Client.Passport,
                        Name = request.Client.Name,
                        LastName = request.Client.LastName,
                        Email = request.Client.Email,
                        CellPhoneNumber = request.Client.CellPhoneNumber
                    },
                    IsValid = true
                };
                return clientValidation;
            }
            clientValidation.Message = "ClientID_NOT_VALID";
            clientValidation.ErrorCode = "ClentId does not exist";
            clientValidation.IsValid = false;
            return clientValidation;
        }

        private IEnumerable<Client> UpdateClient(IEnumerable<Client> clients ,Client clientRequest, int clientId)
        {
            foreach (var client in clients)
            {
                if (client.ClientId == clientId)
                {
                    client.Name = clientRequest.Name;
                    client.LastName = clientRequest.LastName;
                    client.Passport = clientRequest.Passport;
                    client.Email = clientRequest.Email;
                    client.CellPhoneNumber = clientRequest.CellPhoneNumber;
                }
            }
            return clients;
        }
    }
}
