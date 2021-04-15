﻿using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingRequest, Booking>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.ClientRequest))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.RoomRequest))
                .ForMember(dest => dest.availableDate, opt => opt.MapFrom(src => src.AvailableDateRequest));
            CreateMap<Booking, BookingResponse>();

            CreateMap<AvailableDateRequest, AvailableDate>();
            CreateMap<AvailableDate, AvailableDateResponse>();

            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientResponse>();

            CreateMap<RoomRequest, Room>();
            CreateMap<Room, RoomResponse>();
        }
    }
}
