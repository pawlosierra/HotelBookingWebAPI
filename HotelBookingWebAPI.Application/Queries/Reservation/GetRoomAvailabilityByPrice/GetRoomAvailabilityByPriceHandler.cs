using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByPrice
{
    public class GetRoomAvailabilityByPriceHandler : IRequestHandler<GetRoomAvailabilityByPrice, IEnumerable<Room>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetRoomAvailabilityByPriceHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetRoomAvailabilityByPrice request, CancellationToken cancellationToken)
        {
            var rooms = await _reservationRepository.GetAllRooms();
            return rooms.Where(x => x.Availability && x.PriceNight <= request.Price);
        }
    }
}
