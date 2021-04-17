using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRooms
{
    public class GetRoomsHandler : IRequestHandler<GetRooms, IEnumerable<Room>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetRoomsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetRooms request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
