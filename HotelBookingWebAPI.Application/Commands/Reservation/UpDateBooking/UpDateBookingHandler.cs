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
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public UpdateBookingHandler(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<IEnumerable<Booking>> Handle(UpdateBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var bookings = await _reservationRepository.GetBookings();
            var roomAvailable = RoomAvailable(rooms, request.Booking);
            if (roomAvailable.isAvailableRoom)
            {
                var updateRooms = UpdateRoom(rooms, bookings, request.BookingNumber);
                await _roomRepository.UpdateRooms(updateRooms);
                var updateBookings = UpdateBooking(bookings, request.Booking, request.BookingNumber, roomAvailable.roomRequested);
                await _reservationRepository.UpdateBooking(updateBookings);
                var updateRoom = UpdateRoom(roomAvailable.roomRequested, updateRooms, request.Booking);
                await _roomRepository.UpdateRooms(updateRoom);
                return updateBookings;
            }
            return null;
        }

        private IEnumerable<Room> UpdateRoom(Room roomRequested, IEnumerable<Room> rooms, Booking bookingRequest)
        {
            var updateRooms = new List<Room>();
            var updateRoom = new Room();
            foreach (var room in rooms)
            {
                if (room.RoomNumber == roomRequested.RoomNumber)
                {
                    var updateDates = new List<AvailableDate>();
                    foreach (var dateAvailable in room.AvailableDates)
                    {
                        if(dateAvailable.CheckIn != bookingRequest.CheckIn && 
                            dateAvailable.CheckOut != bookingRequest.CheckOut)
                        {
                            updateDates.Add(dateAvailable);
                        }
                    }
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

        private IEnumerable<Booking> UpdateBooking(IEnumerable<Booking> bookings, Booking bookingRequest, int bookingNumber, Room roomRequested)
        {
            var updateBookings = new List<Booking>();
            var updateBooking = new Booking();
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber == bookingNumber)
                {
                    updateBooking.CheckIn = bookingRequest.CheckIn;
                    updateBooking.CheckOut = bookingRequest.CheckOut;
                    updateBooking.BookingNumber = booking.BookingNumber;
                    updateBooking.Client = bookingRequest.Client;
                    //updateBooking.Room = bookingRequest.Room;
                    updateBooking.Travellers = roomRequested.PeoplePerRoom;
                    updateBooking.Room = roomRequested;
                    updateBookings.Add(updateBooking);
                }
                else
                {
                    updateBookings.Add(booking);
                }
            }
            return updateBookings;
        }

        private IEnumerable<Room> UpdateRoom(IEnumerable<Room> rooms,IEnumerable<Booking> bookings, int bookingNumber)
        {
            var updateRooms = new List<Room>();
            var booking = BookingSearch(bookings, bookingNumber);
            foreach (var room in rooms)
            {
                if (room.RoomNumber == booking.Room.RoomNumber)
                {
                    var updateDates = new List<AvailableDate>();
                    var updateDate = new AvailableDate();
                    foreach (var date in room.AvailableDates)
                    {
                        updateDates.Add(date);
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

        private Booking BookingSearch(IEnumerable<Booking> bookings, int bookingNumber)
        {
            foreach (var booking in bookings)
            {
                if (booking.BookingNumber == bookingNumber)
                {
                    return booking;
                }
            }
            return null;
        }

        public (bool isAvailableRoom, Room roomRequested) RoomAvailable(IEnumerable<Room> rooms, Booking bookingRequest)
        {
            bool isAvailableRoom = false;
            var roomRequested = new Room();
            foreach (var room in rooms)
            {
                if (room.PeoplePerRoom == bookingRequest.Room.PeoplePerRoom &&
                    room.RoomArea == bookingRequest.Room.RoomArea &&
                    room.PriceNight == bookingRequest.Room.PriceNight)
                {
                    foreach (var availableDate in room.AvailableDates)
                    {
                        if (availableDate.CheckIn == bookingRequest.CheckIn &&
                            availableDate.CheckOut == bookingRequest.CheckOut)
                        {
                            isAvailableRoom = true;
                            //roomRequested = room;
                            roomRequested.PriceNight = room.PriceNight;
                            roomRequested.RoomNumber = room.RoomNumber;
                            roomRequested.RoomArea = room.RoomArea;
                            roomRequested.PeoplePerRoom = room.PeoplePerRoom;
                            roomRequested.NumberOfBeds = room.NumberOfBeds;
                            roomRequested.Availability = room.Availability;
                            roomRequested.OceanView = room.OceanView;
                            roomRequested.FreeWiFi = room.FreeWiFi;
                            roomRequested.AirConditioning = room.AirConditioning;
                            roomRequested.PetFriendly = room.PetFriendly;
                            roomRequested.ParkingIncluded = room.ParkingIncluded;
                            return (isAvailableRoom, roomRequested);
                        }
                    }
                }
            }
            return (isAvailableRoom, roomRequested);
        }
    }
}
