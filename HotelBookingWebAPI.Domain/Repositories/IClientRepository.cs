using HotelBookingWebAPI.Domain.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(string clientId);
        Task<Client> AddClient(Client client);
        Task<Client> UpdateClient(Client clientRequest);
        Task<bool> Exists(string clientId);
        Task<Client> DeleteClient(string clientId);
    }
}
