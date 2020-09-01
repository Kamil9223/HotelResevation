using HotelReservation.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces
{
    public interface IReservationWriteAccessor
    {
        Task AddReservation(Reservations reservation);
        Task UpdateReservation(Reservations reservation);
        Task RemoveReservation(Reservations reservation);
    }
}
