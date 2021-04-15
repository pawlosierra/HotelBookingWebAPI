using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetAllRoomsAvailability
{
    public class GetAllRoomsAvailabilityHandler : IRequestHandler<GetAllRoomsAvailability, IEnumerable<Room>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllRoomsAvailabilityHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetAllRoomsAvailability request, CancellationToken cancellationToken)
        {
            var rooms = await _reservationRepository.GetAllRooms();
            return rooms.Where(x => x.Availability == true);
        }
    }
}
