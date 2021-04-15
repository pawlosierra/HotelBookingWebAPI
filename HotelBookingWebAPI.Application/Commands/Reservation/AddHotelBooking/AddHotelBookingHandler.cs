using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Reservation.AddHotelBooking
{
    public class AddHotelBookingHandler : IRequestHandler<AddHotelBooking, Booking>
    {
        private readonly IReservationRepository _reservationRepository;

        public AddHotelBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(AddHotelBooking request, CancellationToken cancellationToken)
        {
            var allRooms = await _reservationRepository.GetAllRooms();
            if (CheckAvailability(allRooms, request.Booking))
            {
                var addBooking = await _reservationRepository.AddBooking();
            }
            return null;
        }

        public bool CheckAvailability(IEnumerable<Room> allRooms, Booking booking)
        {
            var bookingRequest = allRooms.Where(x => x.Availability == true && x.Capacity == booking.Room.Capacity && 
                                                     x.PriceNight == booking.Room.PriceNight);
            return true;
        }
    }
}
