﻿using HotelBookingWebAPI.Domain.Models.Reservation;
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
    public class AddBookingHandler : IRequestHandler<AddBooking, BookingValidation>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IClientRepository _clientRepository;

        public AddBookingHandler(IRoomRepository roomRepository, IReservationRepository reservationRepository, IClientRepository clientRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
            _clientRepository = clientRepository;
        }

        public async Task<BookingValidation> Handle(AddBooking request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetClients();
            var rooms = await _roomRepository.GetRooms();
            var bookingValidation = new BookingValidation();
            if (!clients.Any(c => c.ClientId == request.Booking.Client.ClientId))
            {
                bookingValidation.ErrorCode = "UNREGISTERED_CLIENT";
                bookingValidation.Message = $"Client {request.Booking.Client.ClientId} is not valid";
                bookingValidation.IsValid = false;
                return bookingValidation;
            }
                              
            if (IsAvailableRoom(rooms, request.Booking))
            {
                var peoplePerRoom = rooms.Where(r => r.RoomId == request.Booking.Room.RoomId).Select(pr => pr.PeoplePerRoom).FirstOrDefault();
                if (request.Booking.Travellers > peoplePerRoom)
                {
                    bookingValidation.ErrorCode = "NUMBER_OF_TRAVELERS_NOT_ALLOWED";
                    bookingValidation.Message = $" {request.Booking.Travellers} travelers are not allowed for the selected room.";
                    bookingValidation.IsValid = false;
                    return bookingValidation;
                }
                var booking = new Booking
                {
                    CheckIn = request.Booking.CheckIn,
                    CheckOut = request.Booking.CheckOut,
                    BookingNumber = new Random().Next(10000,100000),
                    Travellers = request.Booking.Travellers,
                    Client = new Client
                    {
                        ClientId = request.Booking.Client.ClientId
                    },
                    Room = new Room
                    {
                        RoomId = request.Booking.Room.RoomId
                    }
                };
                var updateRooms = UpdateRooms(rooms, request.Booking);
                await _roomRepository.UpdateRooms(updateRooms);
                await _reservationRepository.AddBooking(booking);
                bookingValidation.Booking = booking;
                bookingValidation.IsValid = true;
                return bookingValidation;
            }
            bookingValidation.ErrorCode = "ROOM_NOT_AVAILABLE";
            bookingValidation.Message = $"The roomId {request.Booking.Room.RoomId} is not available for {request.Booking.CheckIn} to " +
                                        $"{request.Booking.CheckOut}.";
            bookingValidation.IsValid = false;
            return bookingValidation;
        }

        private IEnumerable<Room> UpdateRooms(IEnumerable<Room> rooms, Booking booking)
        {
            var updateRooms = new List<Room>();
            var availableDate = new List<AvailableDate>();
            foreach (var room in rooms)
            {
                if (room.RoomId == booking.Room.RoomId)
                {
                    foreach (var date in room.AvailableDates)
                    {
                        if (date.CheckIn != booking.CheckIn && date.CheckOut != booking.CheckOut)
                        {
                            availableDate.Add(date);
                        }
                    }
                    room.AvailableDates = availableDate;
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
            var guid = Guid.NewGuid();
            var availableRoom = rooms.Any(r => r.AvailableDates.Any(ad => ad.CheckIn == booking.CheckIn && ad.CheckOut == booking.CheckOut) && r.RoomId == booking.Room.RoomId);
            return availableRoom;
        }
    }
}
