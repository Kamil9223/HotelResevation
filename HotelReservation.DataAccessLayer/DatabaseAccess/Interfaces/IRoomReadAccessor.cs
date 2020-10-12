using HotelReservation.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces
{
    public interface IRoomReadAccessor
    {
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms> GetRoom(int roomNumber);
    }
}
