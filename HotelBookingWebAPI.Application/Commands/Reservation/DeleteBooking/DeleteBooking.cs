using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Commands.Reservation.DeleteBooking
{
    public class DeleteBooking : IRequest<IEnumerable<Booking>>
    {
        public DeleteBooking(int bookingNumber)
        {
            BookingNumber = bookingNumber;
        }

        public int BookingNumber { get; set; }
    }
}
