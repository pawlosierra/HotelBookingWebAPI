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
                .ForMember(dest => dest.availableDateModel, opt => opt.MapFrom(src => src.availableDate))
                .ForMember(dest => dest.BookingNumberModel, opt => opt.MapFrom(src => src.BookingNumber));
            CreateMap<Client, ClientModel>();
            CreateMap<Room, RoomModel>();
            CreateMap<AvailableDate, AvailableDateModel>();

            CreateMap<BookingModel, Booking>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.ClientModel))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.RoomModel))
                .ForMember(dest => dest.availableDate, opt => opt.MapFrom(src => src.availableDateModel))
                .ForMember(dest => dest.BookingNumber, opt => opt.MapFrom(src => src.BookingNumberModel));
            CreateMap<ClientModel, Client>();
            CreateMap<AvailableDateModel, AvailableDate>();
        }
    }
}
