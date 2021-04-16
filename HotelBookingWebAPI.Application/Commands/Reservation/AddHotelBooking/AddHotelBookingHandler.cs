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
            var addBooking = new Booking();
            if (allRooms.Any(x => x.Availability == true && x.Capacity == request.Booking.Room.Capacity &&
                                                     x.PriceNight == request.Booking.Room.PriceNight))
            {
                var booking = CheckAvailability(allRooms, request.Booking);
                addBooking = await _reservationRepository.AddBooking(booking);
            }
            return addBooking;
        }

        public Booking CheckAvailability(IEnumerable<Room> allRooms, Booking booking)
        {
            var bookingRequired = new Booking();
            var bookingRequest = allRooms.Where(x => x.Availability == true && x.Capacity == booking.Room.Capacity && 
                                                     x.PriceNight == booking.Room.PriceNight);
            foreach (var item in bookingRequest)
            {
                bookingRequired.Client = booking.Client;
                bookingRequired.availableDate = booking.availableDate;
                bookingRequired.Room = item;
                bookingRequired.BookingNumber = new Random().Next(10000, 100000);
            }
            return bookingRequired;
        }
    }
}
