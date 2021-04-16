using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetAllBookings
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookings, IEnumerable<Booking>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllBookingsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(GetAllBookings request, CancellationToken cancellationToken)
        {
            var bookings = await _reservationRepository.GetAllBookings();
            return bookings;
        }
    }
}
