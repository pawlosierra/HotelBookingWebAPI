using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using HotelBookingWebAPI.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetBookingById
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingById, Booking>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetBookingByIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(GetBookingById request, CancellationToken cancellationToken)
        {
            if (!await _reservationRepository.Exists(request.BookingNumber))
            {
                throw new BookingException("THE_BOOKING_DOES_NOT_EXIST.",
                                           "The bookingNumber not found in the system.");

            }
            return await _reservationRepository.GetBookingById(request.BookingNumber);
        }
    }
}
