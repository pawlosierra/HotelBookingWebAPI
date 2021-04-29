using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Clients.DeleteClient
{
    public class DeleteClientHandler : IRequestHandler<DeleteClient, Client>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(DeleteClient request, CancellationToken cancellationToken)
        {
            if (! await _clientRepository.Exists(request.ClientId))
            {
                throw new ClientException("THE_CLIENT_DOES_NOT_EXIST",
                                          "The client does not exist in the system. Check ClientId");
            }
            var clientDeleted = await _clientRepository.DeleteClient(request.ClientId);
            return clientDeleted;
        }
    }
}
