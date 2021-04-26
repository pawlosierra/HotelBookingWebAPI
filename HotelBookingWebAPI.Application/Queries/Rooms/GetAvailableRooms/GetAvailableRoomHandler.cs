using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoomHandler : IRequestHandler<GetAvailableRoom, IEnumerable<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAvailableRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetAvailableRoom request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRooms();
            var availableRooms = AvailableRooms(rooms, request.CheckIn, request.CheckOut, request.PriceNightMin, request.PriceNightMax,
                                                request.PeoplePerRoom, request.NumberOfBeds, request.RoomArea);
            return availableRooms;
        }

        private IEnumerable<Room> AvailableRooms(IEnumerable<Room> rooms, DateTime checkIn, DateTime checkOut, decimal priceNightMin, decimal priceNightMax, 
                                        int peoplePerRoom, int numberOfBeds, int roomArea)
        {
            var availableRooms = rooms.Where(r => r.AvailableDates.Any(ad => ad.CheckIn >= checkIn && ad.CheckOut >= checkOut) && 
                                                r.PriceNight >= priceNightMin && r.PriceNight <= priceNightMax && r.NumberOfBeds >= numberOfBeds && r.RoomArea >= roomArea &&
                                                r.PeoplePerRoom >= peoplePerRoom);
            var availableRoomsByDate = new List<Room>();
            
            foreach (var room in availableRooms)
            {
                var availableDates = new List<AvailableDate>();
                foreach (var date in room.AvailableDates)
                {
                    if (date.CheckIn >= checkIn && date.CheckOut >= checkOut)
                    {
                        availableDates.Add(date);
                    }
                }
                room.AvailableDates = availableDates;
            }
            return availableRooms;
        }
    }
}
