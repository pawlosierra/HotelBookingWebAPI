using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Infrastructure.Models.Booking;
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
            CreateMap<RoomModel, Room>();
        }
    }
}
