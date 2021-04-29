using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetRooms
{
    public class GetRoomsHandler : IRequestHandler<GetRooms, IEnumerable<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomsHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetRooms request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetRooms();
        }
    }
}
