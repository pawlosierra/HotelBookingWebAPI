using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Reservation.UpdateBooking
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBooking, IEnumerable<Booking>>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(UpdateBooking request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
