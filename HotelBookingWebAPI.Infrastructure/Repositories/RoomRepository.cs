using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _hotelContext;
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public RoomRepository(IMapper mapper, IReservationRepository reservationRepository)
        {
            _hotelContext = new HotelContext();
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public Task<IEnumerable<Room>> GetRooms()
        {
            return Task.Run(() =>
            {
                var rooms = _hotelContext.DeserializeRoomModel();
                var resp = _mapper.Map<IEnumerable<Room>>(rooms);
                return resp;
            });
        }
        public Task<Room> GetRoomById(string roomId)
        {
            return Task.Run(() => 
            {
                var rooms = _hotelContext.DeserializeRoomModel();
                var room = rooms.Where(r => r.RoomId == roomId).First();
                return _mapper.Map<Room>(room);
            });
        }
        public Task UpdateRooms(IEnumerable<Room> updateRooms)
        {
            return Task.Run(() =>
            {
                var roomModel = _mapper.Map<IEnumerable<RoomModel>>(updateRooms);
                _hotelContext.SerializeRooms(roomModel);
            });
        }

        public Task<IEnumerable<Room>> SearchAvailableRooms(DateTime checkIn, DateTime checkOut,
                                                        decimal priceNightMin, decimal priceNightMax,
                                                        int roomArea, int peoplePerRoom, int numberOfBeds)
        {
            return Task.Run(() =>
            {
                var rooms = _hotelContext.DeserializeRoomModel();
                var bookings = _hotelContext.DeserializeBookingModel();
                var matchingRooms = rooms.Where(r => r.PriceNight > priceNightMin
                                                    && r.PriceNight < priceNightMax
                                                    && r.RoomArea > roomArea
                                                    && r.PeoplePerRoom > peoplePerRoom
                                                    && r.NumberOfBeds > numberOfBeds).ToList();
                var availableRooms = new List<RoomModel>();
                matchingRooms.ForEach(async room =>
                {
                    if (await _reservationRepository.IsRoomAvailable(room.RoomId, checkIn, checkOut))
                    {
                        availableRooms.Add(room);
                    }
                });
                return _mapper.Map<IEnumerable<Room>>(availableRooms);
            });
        }

        public Task<bool> Exists(string roomId)
        {
            return Task.Run(()=> 
            {
                var rooms = _hotelContext.DeserializeRoomModel();
                if (rooms.Any(r => r.RoomId == roomId))
                {
                    return true;
                }
                return false;
            });
        }
    }
}
