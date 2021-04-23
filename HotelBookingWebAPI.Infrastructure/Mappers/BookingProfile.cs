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
                //.ForPath(dest => dest.Client.ClientId, opt => opt.MapFrom(src => src.Client.ClientId))
                //.ForPath(dest => dest.Room.RoomId, opt => opt.MapFrom(src => src.Room.RoomId));
                .ForPath(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.ClientId))
                .ForPath(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.RoomId));
            CreateMap<BookingModel, Booking>()
                //.ForPath(dest => dest.Client.ClientId, opt => opt.MapFrom(src => src.Client))
                //.ForPath(dest => dest.Room.RoomId, opt => opt.MapFrom(src => src.Room));
                //.ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                //.ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
                .ForPath(dest => dest.Client.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForPath(dest => dest.Room.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }
    }
}
