﻿using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientResponse>();

            CreateMap<ClientUpdateRequest, Client>();

            CreateMap<ClientValidation, ClientValidationResponse>()
                .ForMember(dest => dest.ClientResponse, opt => opt.MapFrom(src => src.Client));
        }
    }
}