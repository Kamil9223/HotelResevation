using HotelReservation.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces
{
    public interface IReservationReadAccessor
    {
        Task<IEnumerable<Reservations>> GetAllReservations();
        Task<IEnumerable<Reservations>> GetReservationsForGuest(int guestId);
        Task<Reservations> GetReservation(int reservationId);
    }
}
