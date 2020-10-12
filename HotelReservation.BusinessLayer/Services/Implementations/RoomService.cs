using HotelReservation.BusinessLayer.Services.Interfaces;
using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using HotelReservation.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadAccessor _roomReadAccessor;

        public RoomService(IRoomReadAccessor roomReadAccessor)
        {
            _roomReadAccessor = roomReadAccessor;
        }

        public async Task<Rooms> GetRoom(int roomNumber)
        {
            return await _roomReadAccessor.GetRoom(roomNumber);
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _roomReadAccessor.GetRooms();
        }
    }
}
