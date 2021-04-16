using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Reservation.DeleteBooking
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBooking, IEnumerable<Booking>>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            var bookings = await _reservationRepository.GetAllBookings();
            var upDateBookings = UpDateBookings(bookings, request.BookingNumber);
            var upDate = await _reservationRepository.DeleteBooking(upDateBookings);
            return upDate;
        }
        public IEnumerable<Booking> UpDateBookings(IEnumerable<Booking> bookings, int bookingNumber)
        {
            var upDateBooking = new Booking();
            var upDateBookings = new List<Booking>();
            //var existingBooking = bookings.Where(x => x.BookingNumber == bookingNumber);
            foreach (var currentBooking in bookings)
            {
                if (currentBooking.BookingNumber != bookingNumber)
                {
                    upDateBookings.Add(currentBooking);
                }
            }
            return upDateBookings;
        }
    }
}
