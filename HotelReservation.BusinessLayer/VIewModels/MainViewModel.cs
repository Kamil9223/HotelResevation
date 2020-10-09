using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotelReservation.BusinessLayer.Enums;
using System.Windows.Input;


namespace HotelReservation.BusinessLayer.VIewModels
{
    public class MainViewModel : ViewModelBase
    {
        public double WindowWidth { get; } = 900;
        public double WindowHeight { get; } = 600;


        private ContentFillOptions _contentPage;
        public ContentFillOptions ContetnPage
        {
            get => _contentPage;
            set
            {
                _contentPage = value;
                RaisePropertyChanged(nameof(ContetnPage));
            }
        }

        public ICommand ShowReservationsCommand { get; set; }
        public ICommand ShowRoomsCommand { get; set; }

        public MainViewModel()
        {
            ContetnPage = ContentFillOptions.ReservationsList;
            Messenger.Default.Register<ContentFillOptions>(this, (currentPage) =>
            {
                ContetnPage = currentPage;
            });
            ShowRoomsCommand = new RelayCommand(() => ContetnPage = ContentFillOptions.Rooms);
            ShowReservationsCommand = new RelayCommand(() => ContetnPage = ContentFillOptions.ReservationsList);
        }
    }
}
