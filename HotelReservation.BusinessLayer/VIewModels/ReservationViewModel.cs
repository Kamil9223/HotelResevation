using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelReservation.BusinessLayer.Commands;
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

        private ObservableCollection<ReservationHeader> _reservationHeaders;
        public ObservableCollection<ReservationHeader> ReservationsHeaders
        {
            get => _reservationHeaders;
            set
            {
                _reservationHeaders = value;
                RaisePropertyChanged("ReservationsHeaders");
            }
        }

        public ICommand LoadReservations { get; set; }

        private ReservationDetailCommand _showReservationDetails { get; set; }
        public ICommand ShowReservationDetails 
        {
            get => _showReservationDetails;
        }

        public ReservationViewModel(IReservationReadService reservationReader)
        {
            ContetnPage = ContentFillOptions.ReservationsList;
            _reservationReader = reservationReader;
            _showReservationDetails = new ReservationDetailCommand(async (id) =>
            {
                await ShowDetails(id);
                ContetnPage = ContentFillOptions.ReservationsDetails;
            });
            LoadReservations = new RelayCommand(async () =>  await Load());
        }

        public async Task Load()
        {
            var headers = await _reservationReader.GetReservationsHeaders();
            ReservationsHeaders = new ObservableCollection<ReservationHeader>(headers);
            _showReservationDetails.RaiseCanExecuteChanged();
        }

        public async Task ShowDetails(object reservationId)
        {
            var castedId = (int)reservationId;
            var details = await _reservationReader.GetReservationDetail(castedId);
        }
    }
}
