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

namespace HotelBookingWebAPI.Application.Commands.Bookings.DeleteBooking
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBooking, Booking>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            if (! await _reservationRepository.Exists(request.BookingNumber))
            {
                throw new BookingException("THE_BOOKING_NOT_EXIST",
                                           "The booking does not exist. Check bookingId");
            }
            var bookingDeleted = await _reservationRepository.DeleteBooking(request.BookingNumber);
            return bookingDeleted;
        }
    }
}
