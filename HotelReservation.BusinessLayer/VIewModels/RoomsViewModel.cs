using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotelReservation.BusinessLayer.Enums;
using HotelReservation.BusinessLayer.Services.Interfaces;
using HotelReservation.BusinessLayer.UIModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservation.BusinessLayer.VIewModels
{
    public class RoomsViewModel : ViewModelBase
    {
        private readonly IRoomService _roomService;

        private ObservableCollection<RoomHeader> _roomsHeaders;
        public ObservableCollection<RoomHeader> RoomsHeaders
        {
            get => _roomsHeaders;
            set
            {
                _roomsHeaders = value;
                RaisePropertyChanged(nameof(RoomsHeaders));
            }
        }

        private RoomInformation _roomDetails;
        public RoomInformation RoomDetails
        {
            get => _roomDetails;
            set
            {
                _roomDetails = value;
                RaisePropertyChanged(nameof(ReservationDetails));
            }
        }

        public ICommand LoadRooms { get; set; }

        public ICommand ShowRoomDetails { get; set; }

        public RoomsViewModel(IRoomService roomService)
        {
            _roomService = roomService;

            ShowRoomDetails = new RelayCommand<int>(async (id) =>
            {
                await ShowDetails(id);
                Messenger.Default.Send(ContentFillOptions.RoomDetails);
            });

            LoadRooms = new RelayCommand(async () => await Load());
        }

        public async Task ShowDetails(int roomNumber)
        {
            RoomDetails = await _roomService.GetRoom(roomNumber);
        }

        private async Task Load()
        {
            var roomHeaders = await _roomService.GetRooms();
            RoomsHeaders = new ObservableCollection<RoomHeader>(roomHeaders);
        }
    }
}
