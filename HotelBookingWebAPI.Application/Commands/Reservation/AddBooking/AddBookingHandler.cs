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
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public AddBookingHandler(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Booking> Handle(AddBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var bookingAvailability = BookingAvailability(rooms, request.Booking);
            if (bookingAvailability.theRoomIsAvailable)
            {
                var booking = await _reservationRepository.AddBooking(bookingAvailability.bookingAvailability);
                var updateRooms = UpdateRooms(rooms, booking);
                await _roomRepository.UpdateRooms(updateRooms);
                return booking;
            }
            return null;
        }
         
        public IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, Booking booking)
        {
            var updateRooms = new List<Room>();
            var updateAvailableRoomDates = new List<AvailableDate>();
            var updateRoom = new Room();
            foreach (var room in rooms)
            {
                if (room.RoomNumber == booking.Room.RoomNumber)
                {
                    updateRoom.PriceNight = room.PriceNight;
                    updateRoom.RoomNumber = room.RoomNumber;
                    updateRoom.RoomArea = room.RoomArea;
                    updateRoom.PeoplePerRoom = room.PeoplePerRoom;
                    updateRoom.NumberOfBeds = room.NumberOfBeds;
                    updateRoom.Availability = room.Availability;
                    updateRoom.OceanView = room.OceanView;
                    updateRoom.FreeWiFi = room.FreeWiFi;
                    updateRoom.AirConditioning = room.AirConditioning;
                    updateRoom.PetFriendly = room.PetFriendly;
                    updateRoom.ParkingIncluded = room.ParkingIncluded;
                    foreach (var dateAvailable in room.AvailableDates)
                    {
                        if (dateAvailable.CheckIn != booking.CheckIn && dateAvailable.CheckOut != booking.CheckOut)
                        {
                            updateAvailableRoomDates.Add(dateAvailable);
                            updateRoom.AvailableDates = updateAvailableRoomDates;
                        }
                    }
                    updateRooms.Add(updateRoom);
                }
                else
                {
                    updateRooms.Add(room);
                }
            }
            return updateRooms;
        }

        public (Booking bookingAvailability, bool theRoomIsAvailable) BookingAvailability(IEnumerable<Room> rooms, Booking bookingRequest)
        {
            var bookingAvailability = new Booking();
            var theRoomIsAvailable = false;
            foreach (var room in rooms)
            {
                foreach (var availableDate in room.AvailableDates)
                {
                    if (availableDate.CheckIn == bookingRequest.CheckIn && availableDate.CheckOut == bookingRequest.CheckOut)
                    {
                        
                        theRoomIsAvailable = true;
                        bookingAvailability.CheckIn = availableDate.CheckIn;
                        bookingAvailability.CheckOut = availableDate.CheckOut;
                        bookingAvailability.Travellers = bookingRequest.Travellers;
                        bookingAvailability.Room = new Room();
                        bookingAvailability.Room.PriceNight = room.PriceNight;
                        bookingAvailability.Room.RoomNumber = room.RoomNumber;
                        bookingAvailability.Room.RoomArea = room.RoomArea;
                        bookingAvailability.Room.PeoplePerRoom = room.PeoplePerRoom;
                        bookingAvailability.Room.NumberOfBeds = room.NumberOfBeds;
                        bookingAvailability.Room.Availability = room.Availability;
                        bookingAvailability.Room.OceanView = room.OceanView;
                        bookingAvailability.Room.FreeWiFi = room.FreeWiFi;
                        bookingAvailability.Room.AirConditioning = room.AirConditioning;
                        bookingAvailability.Room.PetFriendly = room.PetFriendly;
                        bookingAvailability.Room.ParkingIncluded = room.ParkingIncluded;
                        bookingAvailability.Client = bookingRequest.Client;
                        bookingAvailability.BookingNumber = new Random().Next(10000, 100000);
                    }
                }
            }
            return (bookingAvailability, theRoomIsAvailable);
        }
    }
}
