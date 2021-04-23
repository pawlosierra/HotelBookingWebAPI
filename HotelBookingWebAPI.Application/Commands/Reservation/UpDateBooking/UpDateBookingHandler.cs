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
    public class UpdateBookingHandler : IRequestHandler<UpdateBooking, BookingValidation>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public UpdateBookingHandler(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<BookingValidation> Handle(UpdateBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var bookings = await _reservationRepository.GetBookings();
            var bookingValidation = new BookingValidation();
            if (IsAvailableRoom(rooms, request.Booking))
            {
                if (bookings.Any(b => b.BookingNumber == request.BookingNumber))
                {
                    await _roomRepository.UpdateRooms(UpdateRooms(rooms, request.BookingNumber, bookings));
                    var updateBookings = UpdateBookings(bookings, request.Booking, request.BookingNumber);
                    await _reservationRepository.UpdateBooking(updateBookings);
                    await _roomRepository.UpdateRooms(UpdateRooms(rooms, request.Booking));
                    bookingValidation.Booking.BookingNumber = request.BookingNumber;
                    bookingValidation.Booking = request.Booking;
                    bookingValidation.IsValid = true;
                    return bookingValidation;
                }
                else
                {
                    bookingValidation.ErrorCode = "INVALID_RESERVATION_NUMBER";
                    bookingValidation.Message = $"The bookingNumber {request.Booking.BookingNumber} is not valid";
                    bookingValidation.IsValid = false;
                    return bookingValidation;
                }
            }
            bookingValidation.ErrorCode = "ROOM_NOT_AVAILABLE";
            bookingValidation.Message = $"The roomId {request.Booking.Room.RoomId} is not available for {request.Booking.CheckIn} to " +
                                        $"{request.Booking.CheckOut}.";
            bookingValidation.IsValid = false;
            return bookingValidation;
        }

        //delete the date used in the new reservation
        private IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, Booking booking)
        {
            var updateRooms = new List<Room>();
            var dateAvailables = new List<AvailableDate>();
            
            foreach (var room in rooms)
            {
                if (room.RoomId == booking.Room.RoomId)
                {
                    foreach (var date in room.AvailableDates)
                    {
                        if (date.CheckIn != booking.CheckIn && date.CheckOut != booking.CheckOut)
                        {
                            dateAvailables.Add(date);
                        }
                    }
                    room.AvailableDates = dateAvailables;
                    updateRooms.Add(room);
                }
                else 
                {
                    updateRooms.Add(room);
                }
            }
            return updateRooms;
        }

        private IEnumerable<Booking> UpdateBookings(IEnumerable<Booking> bookings, Booking bookingRequest, int bookingNumber)
        {
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber == bookingNumber)
                {
                    booking.CheckIn = bookingRequest.CheckIn;
                    booking.CheckOut = bookingRequest.CheckOut;
                    booking.Travellers = bookingRequest.Travellers;
                    booking.Room.RoomId = bookingRequest.Room.RoomId;
                }
            }
            return bookings;
        }
        //add the date that is not to be used.
        private IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, int bookingNumber, IEnumerable<Booking> bookings)
        {
            var reservedRoom = bookings.Where(r => r.BookingNumber == bookingNumber).Select(r => new { r.Room, r.CheckIn, r.CheckOut }).FirstOrDefault();
            var updateRooms = new List<Room>();
            var dateAvailables = new List<AvailableDate>();
            var dateAvailable = new AvailableDate();
            foreach (var room in rooms)
            {
                if (room.RoomId == reservedRoom.Room.RoomId)
                {
                    foreach (var date in room.AvailableDates)
                    {
                        dateAvailables.Add(date);
                    }
                    dateAvailable.CheckIn = reservedRoom.CheckIn;
                    dateAvailable.CheckOut = reservedRoom.CheckOut;
                    dateAvailables.Add(dateAvailable);
                    room.AvailableDates = dateAvailables;
                    updateRooms.Add(room);
                }
                else 
                {
                    updateRooms.Add(room);
                }
            }
            return updateRooms;
        }

        private bool IsAvailableRoom(IEnumerable<Room> rooms, Booking booking)
        {
            var availableRoom = rooms.Any(r => r.AvailableDates.Any(ad => ad.CheckIn != booking.CheckIn &&
                                            ad.CheckOut != booking.CheckOut));
            return availableRoom;
        }
    }
}
