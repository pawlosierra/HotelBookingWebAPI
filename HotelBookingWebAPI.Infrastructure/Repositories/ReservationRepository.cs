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
        private readonly HotelContext _roomContext;

        public ReservationRepository(IMapper mapper)
        {
            _mapper = mapper;
            _roomContext = new HotelContext();
        }
        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return null;
        }
        public async Task<Booking> AddBooking(Booking booking)
        {
            return null;
        }
        public async Task<IEnumerable<Booking>> UpDateBooking(IEnumerable<Booking> upDateBooking)
        {
            return null;
        }
        public async Task<IEnumerable<Booking>> DeleteBooking(IEnumerable<Booking> upDateBooking)
        {
            return null;
        }
    }
}
