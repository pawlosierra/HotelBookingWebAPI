﻿using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Clients.AddClient
{
    public class AddClient : IRequest<ClientValidation>
    {
        public AddClient(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}
