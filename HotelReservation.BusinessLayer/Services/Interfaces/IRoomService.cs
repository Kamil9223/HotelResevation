using HotelReservation.BusinessLayer.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Interfaces
{
    public interface IRoomService
    {
        Task<RoomInformation> GetRoom(int roomNumber);
        Task<IEnumerable<RoomHeader>> GetRooms();
    }
}
