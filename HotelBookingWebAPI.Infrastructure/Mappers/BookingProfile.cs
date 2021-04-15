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

            CreateMap<Booking, BookingModel>()
                .ForMember(dest => dest.ClientModel, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.RoomModel, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.availableDateModel, opt => opt.MapFrom(src => src.availableDate));
            CreateMap<Client, ClientModel>();
            CreateMap<Room, RoomModel>();
            CreateMap<AvailableDate, AvailableDateModel>();
        }
    }
}
