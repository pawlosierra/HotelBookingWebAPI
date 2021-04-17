using HotelBookingWebAPI.Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
    }
}
