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
            CreateMap<Booking, BookingResponse>();

            CreateMap<AvailableDate, AvailableDateResponse>();

            CreateMap<Client, ClientResponse>();

            CreateMap<Room, RoomResponse>();
        }
    }
}
