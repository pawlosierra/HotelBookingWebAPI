using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Clients.GetClients
{
    public class GetClients : IRequest<IEnumerable<Client>>
    {
    }
}
