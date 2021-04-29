using HotelBookingWebAPI.Domain.Models.Bookings;
using HotelBookingWebAPI.Domain.Models.Exceptions;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoomsHandler : IRequestHandler<GetAvailableRooms, IEnumerable<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAvailableRoomsHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetAvailableRooms request, CancellationToken cancellationToken)
        {
            if (request.CheckIn < DateTime.Now 
                || (request.CheckOut - request.CheckIn).TotalDays < 1
                || (request.CheckOut - request.CheckIn).TotalDays > 3
                || (request.CheckIn - DateTime.Now).TotalDays > 30)
            {
                throw new RoomException("INVALID_REQUEST.CHECKIN_AND_CHECKOUT_NOT_VALID",
                                        "There is a problem with the dates. " +
                                        "Please check that the CheckIn date is greater than the current date." +
                                        "The CheckOut must be higher than the CheckIn. " +
                                        "The maximum number of days per booking is 3 days. " +
                                        "Reservations can only be made 30 days in advance. ");
            }
            return await _roomRepository.SearchAvailableRooms(request.CheckIn, request.CheckOut, request.PriceNightMin,
                                                request.PriceNightMax, request.RoomArea, request.PeoplePerRoom,
                                                request.NumberOfBeds);
        }
    }
}
