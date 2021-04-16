using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Commands.Reservation.UpDateBooking
{
    public class UpDateBookingHandler : IRequestHandler<UpDateBooking, IEnumerable<Booking>>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpDateBookingHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(UpDateBooking request, CancellationToken cancellationToken)
        {
            var rooms = await _reservationRepository.GetAllRooms();
            var bookings = await _reservationRepository.GetAllBookings();
            var upDateBookings = UpDateBooking(rooms, bookings, request.BookingUpDate, request.BookingNumber);
            var upDate = await _reservationRepository.UpDateBooking(upDateBookings);
            return upDate;
        }

        public IEnumerable<Booking> UpDateBooking(IEnumerable<Room> rooms, IEnumerable<Booking> bookings, Booking bookingUpDateRequest, int bookingNumber)
        {
            var upDateBooking = new Booking();
            var upDateBookings = new List<Booking>();
            var existingBooking = bookings.Where(x => x.BookingNumber == bookingNumber);
            foreach (var currentBooking in bookings)
            {
                if (currentBooking.BookingNumber == bookingNumber)
                {
                    var roomInformation = IsTheRoomAvailable(rooms, bookingUpDateRequest);
                    if (roomInformation.isTheRoomAvailable)
                    {
                        var roomNumber = roomInformation.roomNumber;
                        foreach (var reservation in existingBooking)
                        {
                            reservation.Client = bookingUpDateRequest.Client;
                            reservation.Room = bookingUpDateRequest.Room;
                            reservation.Room.RoomNumber = roomInformation.roomNumber;
                            reservation.availableDate.CheckIn = bookingUpDateRequest.availableDate.CheckIn;
                            reservation.availableDate.CheckOut = bookingUpDateRequest.availableDate.CheckOut;
                            upDateBookings.Add(reservation);
                        }
                    }
                }
                else 
                {
                    upDateBookings.Add(currentBooking);
                }
            }
            return upDateBookings;
        }

        public (bool isTheRoomAvailable, int roomNumber) IsTheRoomAvailable(IEnumerable<Room> rooms, Booking bookingUpDateRequest)
        {
            var availableRooms = rooms.Where(x => x.Availability == true
                                            && x.Capacity == bookingUpDateRequest.Room.Capacity
                                            && x.PriceNight == bookingUpDateRequest.Room.PriceNight);
            foreach (var roomOption in availableRooms)
            {
                foreach (var availableDate in roomOption.AvailableDate)
                {
                    if (availableDate.CheckIn == bookingUpDateRequest.availableDate.CheckIn)
                    {
                        return (true, roomOption.RoomNumber);
                    }
                }
            }
            return (false, 0);
        }
    }
}
