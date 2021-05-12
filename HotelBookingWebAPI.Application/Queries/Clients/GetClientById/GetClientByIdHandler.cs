using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Clients.GetClientById
{
    public class GetClientByIdHandler : IRequestHandler<GetClientById, Client>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientByIdHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> Handle(GetClientById request, CancellationToken cancellationToken)
        {
            if (!await _clientRepository.Exists(request.ClientId))
            {
                throw new ClientException("THE_CLIENT_DOES_NOT_EXIST",
                                          "The client does not exist in the system. Check ClientId");

            }
            return await _clientRepository.GetClientById(request.ClientId);
        }
    }
}
