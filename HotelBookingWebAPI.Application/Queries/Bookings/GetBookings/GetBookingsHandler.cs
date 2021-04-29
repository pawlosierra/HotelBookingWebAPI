using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetBookings
{
    public class GetBookingsHandler : IRequestHandler<GetBookings, IEnumerable<Booking>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetBookingsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(GetBookings request, CancellationToken cancellationToken)
        {
            var bookings = await _reservationRepository.GetBookings();
            return bookings;
        }

    }
}
