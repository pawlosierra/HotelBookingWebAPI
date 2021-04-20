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
        private readonly IRoomRepository _roomRepository;

        public DeleteBookingHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var bookings = await _reservationRepository.GetBookings();
            var validBooking = ValidBooking(bookings, request.BookingNumber);
            if (validBooking.isValidBooking)
            {
                var updateRooms = UpdateRooms(rooms, validBooking.Booking);
                await _roomRepository.UpdateRooms(updateRooms);
                var updateBooking = UpdateBookings(bookings, validBooking.Booking);
                await _reservationRepository.UpdateBooking(updateBooking);
                return updateBooking;
            }
            return null;
        }

        private IEnumerable<Booking> UpdateBookings(IEnumerable<Booking> bookings, Booking bookingRequest)
        {
            var updateBookings = new List<Booking>();
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber != bookingRequest.BookingNumber)
                {
                    updateBookings.Add(booking);
                }
            }
            return updateBookings;
        }

        private IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, Booking booking)
        {
            var updateRooms = new List<Room>();
            var updateRoom = new Room();
            foreach (var room in rooms)
            {
                if (room.RoomNumber == booking.Room.RoomNumber)
                {
                    var updateDates = new List<AvailableDate>();
                    var updateDate = new AvailableDate();
                    foreach (var availableDate in room.AvailableDates)
                    {
                        updateDates.Add(availableDate);
                    }
                    updateDate.CheckIn = booking.CheckIn;
                    updateDate.CheckOut = booking.CheckOut;
                    updateDates.Add(updateDate);
                    room.AvailableDates = updateDates;
                    updateRooms.Add(room);
                }
                else
                {
                    updateRooms.Add(room);
                }
            }
            return updateRooms;
        }

        private (bool isValidBooking, Booking Booking) ValidBooking(IEnumerable<Booking> bookings, int bookingNumber)
        {
            bool isValidBooking = false;
            var validBooking = new Booking();
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber == bookingNumber)
                {
                    validBooking = booking;
                    isValidBooking = true;
                    return (isValidBooking, validBooking);
                }
            }
            return (isValidBooking, validBooking);
        }
    }
}
