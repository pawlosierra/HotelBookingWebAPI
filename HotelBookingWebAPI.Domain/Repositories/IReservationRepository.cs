using HotelBookingWebAPI.Domain.Models.Bookings;
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
        Task<Booking> UpdateBooking(Booking bookingRequest);
        Task<Booking> DeleteBooking(string bookingId);

        Task<bool> IsRoomAvailable(string roomId, DateTime checkin, DateTime checkout);
        Task<bool> Exists(string bookingId);
    }
}
