using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Infrastructure.Models.Booking;
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
                .ForPath(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.ClientId))
                .ForPath(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.RoomId));
            CreateMap<BookingModel, Booking>()
                .ForPath(dest => dest.Client.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForPath(dest => dest.Room.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }
    }
}
