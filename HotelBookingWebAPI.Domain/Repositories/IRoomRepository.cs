using HotelBookingWebAPI.Domain.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRooms();
        Task UpdateRooms(IEnumerable<Room> updateRooms);
        Task<IEnumerable<Room>> SearchAvailableRooms(DateTime chechIn, DateTime checkOut, decimal priceNightMin,
                                                decimal priceNightMax, int RoomArea, int peoplePerRoom, int NumberOfBeds);
    }
}
