using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Reservation.GetRoomAvailabilityByDate
{
    public class GetRoomAvailabilityByDateHandler : IRequestHandler<GetRoomAvailabilityByDate, IEnumerable<Room>>
    {
        private readonly IReservationRepository _reservationRepository;
        //private readonly AvailableDate _availableDate;

        public GetRoomAvailabilityByDateHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            //_availableDate = availableDate;
        }

        public async Task<IEnumerable<Room>> Handle(GetRoomAvailabilityByDate request, CancellationToken cancellationToken)
        {
            var rooms = await _reservationRepository.GetAllRooms();
            var availableRooms = rooms.Where(x => x.Availability == true);
            var availableRoomsByDate = new List<Room>();
            foreach (var room in availableRooms)
            {
                foreach (var roomsByDate in room.AvailableDate)
                {
                    if (roomsByDate.CheckIn == request.DateOfEntry)
                    {
                        availableRoomsByDate.Add(room);
                    }
                }
            }
            return availableRoomsByDate;
        }
    }
}
