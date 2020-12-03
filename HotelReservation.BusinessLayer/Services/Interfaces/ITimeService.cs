using System;

namespace HotelReservation.BusinessLayer.Services.Interfaces
{
    public interface ITimeService
    {
        bool IsActualTimeInRange(DateTime from, DateTime to);
    }
}
