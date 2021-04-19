using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingModel>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
            CreateMap<BookingModel, Booking>();

            CreateMap<Client, ClientModel>();
            CreateMap<ClientModel, Client>();

        }
    }
}
