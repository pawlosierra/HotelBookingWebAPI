using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Bookings.UpdateBooking
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBooking, Booking>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(UpdateBooking request, CancellationToken cancellationToken)
        {
            if (! await _reservationRepository.Exists(request.BookingNumber))
            {
                throw new BookingException("THE_BOOKING_DOES_NOT_EXIST.",
                                           "The bookingNumber not found in the system.");

            }
            if ((request.Booking.CheckIn < DateTime.Now
                || (request.Booking.CheckOut - request.Booking.CheckIn).TotalDays < 1
                || (request.Booking.CheckOut - request.Booking.CheckIn).TotalDays > 3
                || (request.Booking.CheckIn - DateTime.Now).TotalDays > 30))
            {
                throw new BookingException("INVALID_REQUEST.CHECKIN_AND_CHECKOUT_NOT_VALID",
                                           "There is a problem with the booking dates. " +
                                           "Please check that the CheckIn date is greater than the current date." +
                                           "The CheckOut must be higher than the CheckIn. " +
                                           "The maximum number of days per booking is 3 days. " +
                                           "Reservations can only be made 30 days in advance.");
                
                
            }
            if (!await _reservationRepository.IsRoomAvailable(request.Booking.Room.RoomId, request.Booking.CheckIn, request.Booking.CheckOut))
            {
                throw new BookingException("ROOM_NOT_AVAILABLE",
                                          $"The roomId {request.Booking.Room.RoomId} is not available for {request.Booking.CheckIn} to " +
                                          $"{request.Booking.CheckOut}.");
            }
            var updateBooking = await _reservationRepository.UpdateBooking(request.Booking);
            return updateBooking;
        }
    }
}
