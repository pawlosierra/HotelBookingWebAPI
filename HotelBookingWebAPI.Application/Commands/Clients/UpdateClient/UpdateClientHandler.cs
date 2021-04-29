using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Models.Bookings;
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
    public class UpdateClientHandler : IRequestHandler<UpdateClient, Client>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(UpdateClient request, CancellationToken cancellationToken)
        {
            if (! await _clientRepository.Exists(request.ClientId))
            {
                throw new ClientException("THE_CLIENT_DOES_NOT_EXIST",
                                          "The client does not exist in the system. Check ClientId");

            }
            var updatedClient = await _clientRepository.UpdateClient(request.Client);
            return updatedClient;
        }
    }
}
