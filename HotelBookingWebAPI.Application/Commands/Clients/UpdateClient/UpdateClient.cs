using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Clients.UpdateClient
{
    public class UpdateClient : IRequest<ClientValidation>
    {
        public UpdateClient(Client client, int clientId)
        {
            Client = client;
            ClientId = clientId;
        }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
