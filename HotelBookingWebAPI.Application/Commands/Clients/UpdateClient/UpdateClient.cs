using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Clients.UpdateClient
{
    public class UpdateClient : IRequest<Client>
    {
        public UpdateClient(Client client, string clientId)
        {
            Client = client;
            ClientId = clientId;
        }

        public Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
