using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
