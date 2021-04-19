using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Room;
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

        public RoomRepository(IMapper mapper)
        {
            _hotelContext = new HotelContext();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var rooms = _hotelContext.DeserializeRoomModel();
            var resp = _mapper.Map<IEnumerable<Room>>(rooms);
            return resp;
        }

        public async Task UpdateRooms(IEnumerable<Room> updateRooms)
        {
            var roomModel = _mapper.Map<IEnumerable<RoomModel>>(updateRooms);
            _hotelContext.SerializeRooms(roomModel);
        }
    }
}
