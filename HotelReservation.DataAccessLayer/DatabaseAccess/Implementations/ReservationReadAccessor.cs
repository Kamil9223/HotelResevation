using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using HotelReservation.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Implementations
{
    public class ReservationReadAccessor : IReservationReadAccessor
    {
        private readonly HotelReservationContext _context;

        public ReservationReadAccessor(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservations>> GetAllReservations()
        {
            return await _context.Reservations.Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservations>> GetReservationsForGuest(int guestId)
        {
            return await _context.Reservations.Include(x => x.Room)
                .Include(x => x.Guest)
                .Where(x => x.Guest.GuestId == guestId)
                .ToListAsync();
        }

        public async Task<Reservations> GetReservation(int reservationId)
        {
            return await _context.Reservations.Include(x => x.Guest)
                .SingleOrDefaultAsync(x => x.ReservationId == reservationId);
        }
    }
}
