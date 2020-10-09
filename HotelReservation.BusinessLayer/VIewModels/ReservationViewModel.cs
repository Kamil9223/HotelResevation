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
    public class ReservationViewModel : ViewModelBase
    {
        private readonly IReservationReadService _reservationReader;

        private ObservableCollection<ReservationHeader> _reservationHeaders;
        public ObservableCollection<ReservationHeader> ReservationsHeaders
        {
            get => _reservationHeaders;
            set
            {
                _reservationHeaders = value;
                RaisePropertyChanged(nameof(ReservationsHeaders));
            }
        }

        private ReservationDetails _reservationDetails;
        public ReservationDetails ReservationDetails
        {
            get => _reservationDetails;
            set
            {
                _reservationDetails = value;
                RaisePropertyChanged(nameof(ReservationDetails));
            }
        }

        public ICommand LoadReservations { get; set; }
        public ICommand ShowReservationDetails { get; set; }


        public ReservationViewModel(IReservationReadService reservationReader)
        {
            _reservationReader = reservationReader;

            ShowReservationDetails = new RelayCommand<int>(async (id) =>
            {
                await ShowDetails(id);
                Messenger.Default.Send(ContentFillOptions.ReservationsDetails);
            });

            LoadReservations = new RelayCommand(async () =>  await Load());   
        }

        public async Task Load()
        {
            var headers = await _reservationReader.GetReservationsHeaders();
            ReservationsHeaders = new ObservableCollection<ReservationHeader>(headers);
        }

        public async Task ShowDetails(int reservationId)
        {
            ReservationDetails = await _reservationReader.GetReservationDetail(reservationId);
        }
    }
}
