using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetRoomById
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomById, Room>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> Handle(GetRoomById request, CancellationToken cancellationToken)
        {
            if (!await _roomRepository.Exists(request.RoomId))
            {
                throw new RoomException("ROOM_NOT_EXIST",
                                        "Room not exist, check the roomId");
            }
            return await _roomRepository.GetRoomById(request.RoomId);
        }
    }
}
