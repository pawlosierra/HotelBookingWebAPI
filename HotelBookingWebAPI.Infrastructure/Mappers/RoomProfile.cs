using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Infrastructure.Mappers
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomModel>();
            CreateMap<AvailableDate, AvailableDateModel>();

            CreateMap<RoomModel, Room>()
                .ForMember(dest => dest.AvailableDates, opt => opt.MapFrom(src => src.AvailableDates));
            CreateMap<AvailableDateModel, AvailableDate>();
        }
    }
}
