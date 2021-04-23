using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Clients.GetClients
{
    public class GetClientsHandler : IRequestHandler<GetClients, IEnumerable<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientsHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> Handle(GetClients request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetClients();
        }
    }
}
