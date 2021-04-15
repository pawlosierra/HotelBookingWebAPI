using HotelBookingWebAPI.Domain.Models.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByPrice
{
    public class GetRoomAvailabilityByPrice : IRequest<IEnumerable<Room>>
    {
        public GetRoomAvailabilityByPrice(decimal price)
        {
            Price = price;
        }

        public decimal Price { get; set; }
    }
}
