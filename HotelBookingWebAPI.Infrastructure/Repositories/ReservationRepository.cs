using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IMapper _mapper;
        private readonly RoomContext _roomContext;

        public ReservationRepository(IMapper mapper)
        {
            _mapper = mapper;
            _roomContext = new RoomContext();
        }
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = _roomContext.DeserializeRoomModel();
            var result = _mapper.Map<IEnumerable<Room>>(rooms);
            return result;
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            var bookingModel = _mapper.Map<BookingModel>(booking);
            _roomContext.SerializeBooking(bookingModel);
            return booking;
        }
    }
}
