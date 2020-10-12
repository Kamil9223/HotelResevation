using GalaSoft.MvvmLight;
using HotelReservation.BusinessLayer.Services.Interfaces;

namespace HotelReservation.BusinessLayer.VIewModels
{
    public class RoomsViewModel : ViewModelBase
    {
        private readonly IRoomService _roomService;

        public RoomsViewModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
    }
}
