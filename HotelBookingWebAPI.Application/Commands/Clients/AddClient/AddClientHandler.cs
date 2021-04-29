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
            var clientCreated = await _clientRepository.AddClient(request.Client);
            return clientCreated;
        }
    }
}
