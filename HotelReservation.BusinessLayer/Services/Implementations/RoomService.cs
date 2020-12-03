using HotelReservation.BusinessLayer.Services.Interfaces;
using HotelReservation.BusinessLayer.UIModels;
using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using HotelReservation.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadAccessor _roomReadAccessor;
        private readonly ITimeService _timeService;

        public RoomService(IRoomReadAccessor roomReadAccessor, ITimeService timeService)
        {
            _roomReadAccessor = roomReadAccessor;
            _timeService = timeService;
        }

        public async Task<RoomInformation> GetRoom(int roomNumber)
        {
            var room = await _roomReadAccessor.GetRoom(roomNumber);

            return new RoomInformation
            {
                RoomNumber = room.RoomNumber,
                RoomType = room.RoomType,
                Floor = room.Floor,
                Area = room.Area,
                PricePerNight = room.PricePerNight,
                NumberOfPlaces = room.NumberOfPlaces,
                IsOccupiedNow = IsOccupied(room)
            };
        }

        public async Task<IEnumerable<RoomHeader>> GetRooms()
        {
            var rooms =  await _roomReadAccessor.GetRooms();
            var roomsHeaders = new List<RoomHeader>();

            foreach(var room in rooms)
            {
                roomsHeaders.Add(new RoomHeader
                {
                    RoomNumber = room.RoomNumber,
                    NumberOfPlaces = room.NumberOfPlaces,
                    PricePerNight = room.PricePerNight,
                    RoomType = (Enums.RoomType)room.RoomType
                });
            }

            return roomsHeaders;
        }

        private bool IsOccupied(Rooms room)
        {
            if (!room.Reservations.Any())
                return false;

            return room.Reservations.Any(x => _timeService.IsActualTimeInRange(x.DateFrom, x.DateTo));
        }
    }
}
