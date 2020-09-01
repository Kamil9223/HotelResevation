using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
                RaisePropertyChanged("ContetnPage");
            }
        }

        public ICommand ShowReservationsCommand { get; set; }
        public ICommand ShowRoomsCommand { get; set; }

        public MainViewModel()
        {
            ShowRoomsCommand = new RelayCommand(() => ContetnPage = ContentFillOptions.Rooms);
            ShowReservationsCommand = new RelayCommand(() => ContetnPage = ContentFillOptions.Reservations);
        }
    }
}
