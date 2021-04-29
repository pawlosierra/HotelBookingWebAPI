using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Clients.DeleteClient
{
    public class DeleteClient : IRequest<Client>
    {
        public DeleteClient(string clientId)
        {
            ClientId = clientId;
        }

        public string ClientId { get; set; }
    }
}
