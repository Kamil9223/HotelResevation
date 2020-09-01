using HotelReservation.BusinessLayer.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Interfaces
{
    public interface IReservationReadService
    {
        Task<IEnumerable<ReservationHeader>> GetReservationsHeaders();
        Task<ReservationDetails> GetReservationDetail(int reservationId);
    }
}
