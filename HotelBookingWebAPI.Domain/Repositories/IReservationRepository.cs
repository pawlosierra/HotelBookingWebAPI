using HotelBookingWebAPI.Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> AddBooking(Booking booking);
        Task<IEnumerable<Booking>> UpdateBooking(IEnumerable<Booking> updateBooking);
        Task<IEnumerable<Booking>> DeleteBooking(IEnumerable<Booking>updateBooking);
    }
}
