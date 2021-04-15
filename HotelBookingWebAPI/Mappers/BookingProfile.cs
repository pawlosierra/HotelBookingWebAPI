using AutoMapper;
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
            CreateMap<BookingRequest, Booking>();
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
