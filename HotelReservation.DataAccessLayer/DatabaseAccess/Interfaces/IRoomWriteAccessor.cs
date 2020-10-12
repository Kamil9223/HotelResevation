using System.Threading.Tasks;

namespace HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces
{
    public interface IRoomWriteAccessor
    {
        Task AddRoom();
    }
}
