using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _hotelContext;
        private readonly IMapper _mapper;

        public RoomRepository(HotelContext hotelContext, IMapper mapper)
        {
            _hotelContext = hotelContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return null;
        }
    }
}
