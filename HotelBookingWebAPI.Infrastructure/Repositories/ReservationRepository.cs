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
        private readonly HotelContext _hotelContext;

        public ReservationRepository(IMapper mapper)
        {
            _mapper = mapper;
            _hotelContext = new HotelContext();
        }
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            var bookings = _hotelContext.DeserializeBookingModel();
            var resp = _mapper.Map<IEnumerable<Booking>>(bookings);
            return resp;
        }
        public async Task<Booking> AddBooking(Booking booking)
        {
            var bookingModel = _mapper.Map<BookingModel>(booking);
            _hotelContext.SerializeBooking(bookingModel);
            return booking;
        }
        public async Task<IEnumerable<Booking>> UpdateBooking(IEnumerable<Booking> updateBooking)
        {
            return null;
        }
        public async Task<IEnumerable<Booking>> DeleteBooking(IEnumerable<Booking> updateBooking)
        {
            return null;
        }
    }
}
