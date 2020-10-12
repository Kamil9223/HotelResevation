using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using HotelReservation.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Implementations
{
    public class RoomReadAccessor : IRoomReadAccessor
    {
        private readonly HotelReservationContext _context;

        public RoomReadAccessor(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task<Rooms> GetRoom(int roomNumber)
        {
            return await _context.Rooms
                .SingleOrDefaultAsync(x => x.RoomNumber == roomNumber);
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
