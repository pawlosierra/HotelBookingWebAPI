using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<RoomModel, Room>()
                .ForMember(dest => dest.AvailableDate, opt => opt.MapFrom(src => src.AvailableDateModel));
            CreateMap<AvailableDateModel, AvailableDate>();
        }
    }
}
