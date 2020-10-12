using HotelReservation.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Rooms> GetRoom(int roomNumber);
        Task<IEnumerable<Rooms>> GetRooms();
    }
}
