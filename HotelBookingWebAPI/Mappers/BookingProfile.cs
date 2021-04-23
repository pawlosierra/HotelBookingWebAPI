using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Reservation;
using HotelBookingWebAPI.DTOs.Room;
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
                .ForPath(dest => dest.Client.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForPath(dest => dest.Room.RoomId, opt => opt.MapFrom(src => src.RoomId));

            CreateMap<Booking, BookingResponse>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.ClientId))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.RoomId));

            CreateMap<BookingValidation, BookingValidatioResponse>()
                .ForMember(dest => dest.BookingResponse, opt => opt.MapFrom(src => src.Booking));
        }
    }
}
