using HotelBookingWebAPI.Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Booking> AddBooking(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<IEnumerable<Booking>> UpDateBooking(IEnumerable<Booking> upDateBooking);
        Task<IEnumerable<Booking>> DeleteBooking(IEnumerable<Booking>upDateBooking);
    }
}
