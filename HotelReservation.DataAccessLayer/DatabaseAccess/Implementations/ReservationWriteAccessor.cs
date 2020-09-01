using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using HotelReservation.DataAccessLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Implementations
{
    public class ReservationWriteAccessor : IReservationWriteAccessor
    {
        private readonly HotelReservationContext _context;

        public ReservationWriteAccessor(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task AddReservation(Reservations reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservation(Reservations reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveReservation(Reservations reservation)
        {
            _context.Reservations.Remove(reservation);

            if (_context.Reservations.Count(x => x.GuestId == reservation.GuestId) < 2)
                _context.Guests.Remove(reservation.Guest);

            await _context.SaveChangesAsync();
        }
    }
}
