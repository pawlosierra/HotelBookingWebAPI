using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Clients.GetClientById
{
    public class GetClientById : IRequest<Client>
    {
        public GetClientById(string clientId)
        {
            ClientId = clientId;
        }

        public string ClientId { get; set; }
    }
}
