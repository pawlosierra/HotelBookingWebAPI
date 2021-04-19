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
            var availableRooms = AvailableRooms(rooms, request.CheckIn, request.CheckOut, request.PriceNight,
                                                request.RoomArea, request.PeoplePerRoom, request.NumberOfBeds,
                                                request.Availability, request.OceanView, request.FreeWiFi,
                                                request.AirConditioning, request.PetFriendly, request.ParkingIncluded);
            return availableRooms;
        }

        private IEnumerable<Room> AvailableRooms(IEnumerable<Room> rooms, DateTime checkIn, DateTime checkOut, decimal priceNight, 
                                        int roomArea, int peoplePerRoom, int numberOfBeds, 
                                        bool availability, bool oceanView, bool freeWiFi, 
                                        bool airConditioning, bool petFriendly, bool parkingIncluded)
        {
            var availableRooms = new List<Room>();
            foreach (var room in rooms)
            {
                var availableDates = new List<AvailableDate>();
                var availableRoom = new Room();
                bool isAnAvailableDate = false;
                availableRoom.PriceNight = room.PriceNight;
                availableRoom.RoomNumber = room.RoomNumber;
                availableRoom.RoomArea = room.RoomArea;
                availableRoom.PeoplePerRoom = room.PeoplePerRoom;
                availableRoom.NumberOfBeds = room.NumberOfBeds;
                availableRoom.Availability = room.Availability;
                availableRoom.OceanView = room.OceanView;
                availableRoom.FreeWiFi = room.FreeWiFi;
                availableRoom.AirConditioning = room.AirConditioning;
                availableRoom.PetFriendly = room.PetFriendly;
                availableRoom.ParkingIncluded = room.ParkingIncluded;
                foreach (var date in room.AvailableDates)
                {
                    if (date.CheckIn >= checkIn && date.CheckOut >= checkOut)
                    #region
                    //&& 
                    //room.PeoplePerRoom == peoplePerRoom && room.PriceNight >= priceNight &&
                    //room.RoomArea >= roomArea && room.NumberOfBeds == numberOfBeds && 
                    //room.Availability == availability && room.OceanView == oceanView &&
                    //room.FreeWiFi == freeWiFi && room.AirConditioning == airConditioning &&
                    //room.PetFriendly == petFriendly && room.ParkingIncluded == parkingIncluded)
                    #endregion
                    {
                        isAnAvailableDate = true;
                        availableDates.Add(date);
                        availableRoom.AvailableDates = availableDates;
                    }
                }
                if (isAnAvailableDate)
                {
                    availableRooms.Add(availableRoom);
                }
            }
            return availableRooms;
        }
    }
}
