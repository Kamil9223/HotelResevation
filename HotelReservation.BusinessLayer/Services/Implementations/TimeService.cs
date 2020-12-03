using HotelReservation.BusinessLayer.Services.Interfaces;
using System;

namespace HotelReservation.BusinessLayer.Services.Implementations
{
    public class TimeService : ITimeService
    {
        public bool IsActualTimeInRange(DateTime from, DateTime to)
        {
            var actualTime = DateTime.Now;

            return actualTime >= from && actualTime <= to;
        }
    }
}
