using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Clients.AddClient
{
    public class AddClient : IRequest<Client>
    {
        public AddClient(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}
