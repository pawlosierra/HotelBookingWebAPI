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
    public class DeleteBookingHandler : IRequestHandler<DeleteBooking, BookingValidation>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;

        public DeleteBookingHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingValidation> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var bookings = await _reservationRepository.GetBookings();
            var bookingValidation = new BookingValidation();
            if (bookings.Any(b => b.BookingNumber == request.BookingNumber))
            {
                await _roomRepository.UpdateRooms(UpdateRooms(rooms, bookings, request.BookingNumber));
                await _reservationRepository.DeleteBooking(UpdateBookings(bookings, request.BookingNumber));
                var reservedRoom = bookings.Where(b => b.BookingNumber == request.BookingNumber).FirstOrDefault();
                bookingValidation.Booking = reservedRoom;
                bookingValidation.IsValid = true;
                return bookingValidation;
            }
            bookingValidation.ErrorCode = "INVALID_BOOKING_NUMBER";
            bookingValidation.Message = $"The bookingNumber {request.BookingNumber} is not valid. Not exist.";
            bookingValidation.IsValid = false;
            return bookingValidation;
        }

        private IEnumerable<Booking> UpdateBookings(IEnumerable<Booking> bookings, int bookingNumber)
        {
            var updateBookings = new List<Booking>();
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber != bookingNumber)
                {
                    updateBookings.Add(booking);
                }
            }
            return updateBookings;
        }

        private IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, IEnumerable<Booking> bookings ,int bookingNumber)
        {
            var reservedRoom = bookings.Where(r => r.BookingNumber == bookingNumber).Select(r => new { r.Room, r.CheckIn, r.CheckOut }).FirstOrDefault();
            var updateRooms = new List<Room>();
            var availableDates = new List<AvailableDate>();
            var availableDate = new AvailableDate();
            foreach (var room in rooms)
            {
                if (room.RoomId == reservedRoom.Room.RoomId)
                {
                    foreach (var date in room.AvailableDates)
                    {
                        availableDates.Add(date);
                    }
                    availableDate.CheckIn = reservedRoom.CheckIn;
                    availableDate.CheckOut = reservedRoom.CheckOut;
                    availableDates.Add(availableDate);
                    room.AvailableDates = availableDates;
                    updateRooms.Add(room);
                }
                else 
                {
                    updateRooms.Add(room);
                }
            }
            return updateRooms;
        }
    }
}
