using AutoMapper;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Data;
using HotelBookingWebAPI.Infrastructure.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<Booking>> GetBookings()
        {
            return Task.Run(() =>
            {
                var bookings = _hotelContext.DeserializeBookingModel();
                return _mapper.Map<IEnumerable<Booking>>(bookings);
            });
        }
        public Task<Booking> AddBooking(Booking booking)
        {
            return Task.Run(() =>
            {
                var bookingModel = _mapper.Map<BookingModel>(booking);
                bookingModel.BookingNumber = Guid.NewGuid().ToString();
                _hotelContext.SerializeBooking(bookingModel);
                var bookingCreated = _mapper.Map<Booking>(bookingModel);
                return bookingCreated;
            });
        }
        public Task<Booking> UpdateBooking(Booking bookingRequest)
        {
            return Task.Run(() =>
            {
                var bookingModel = _mapper.Map<BookingModel>(bookingRequest);
                var bookings = _hotelContext.DeserializeBookingModel();
                foreach (var booking in bookings)
                {
                    if (booking.BookingNumber == bookingRequest.BookingNumber)
                    {
                        booking.CheckIn = bookingModel.CheckIn;
                        booking.CheckOut = bookingModel.CheckOut;
                        booking.Travellers = bookingModel.Travellers;
                        booking.RoomId = bookingModel.RoomId;
                    }
                }
                _hotelContext.SerializeBookings(bookings);
                return bookingRequest;
            });
        }
        public Task<Booking> DeleteBooking(string bookingId)
        {
            return Task.Run(() => 
            {
                var bookings = _hotelContext.DeserializeBookingModel();
                var bookingDeleted = bookings.Where(b => b.BookingNumber == bookingId).FirstOrDefault();
                var updatedBooking = bookings.Where(b => b.BookingNumber != bookingId);
                _hotelContext.SerializeBookings(updatedBooking);
                return _mapper.Map<Booking>(bookingDeleted);
            });
        }

        public Task<bool> IsRoomAvailable(string roomId, DateTime checkin, DateTime checkout)
        {
            return Task.Run(() =>
            {
                var bookings = _hotelContext.DeserializeBookingModel();
                if (bookings.Any(b => b.RoomId == roomId 
                && ((b.CheckIn <= checkin && checkin <= b.CheckOut) || (b.CheckIn <= checkout && checkout <= b.CheckOut))))
                {
                    return false;
                }
                return true;
            });
        }

        public Task<bool> Exists(string bookingId)
        {
            return Task.Run(() => 
            {
                var bookings = _hotelContext.DeserializeBookingModel();
                if (bookings.Any(b => b.BookingNumber == bookingId))
                {
                    return true;
                }
                return false;
            });
        }
    }
}
