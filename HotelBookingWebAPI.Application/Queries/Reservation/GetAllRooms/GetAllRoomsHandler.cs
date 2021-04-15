using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetAllRooms
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRooms, IEnumerable<Room>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllRoomsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetAllRooms request, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetAllRooms();
        }
    }
}
