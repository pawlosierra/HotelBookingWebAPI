using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Infrastructure.Models.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModel>();
            CreateMap<ClientModel, Client>();
        }
    }
}
