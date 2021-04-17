using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Reservation.AddBooking
{
    public class AddBookingHandler : IRequestHandler<AddBooking, Booking>
    {
        private readonly IReservationRepository _reservationRepository;

        public AddBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(AddBooking request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
