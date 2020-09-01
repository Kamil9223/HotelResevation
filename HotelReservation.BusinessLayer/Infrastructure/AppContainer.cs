using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using HotelReservation.BusinessLayer.Enums;
using HotelReservation.BusinessLayer.Services.Implementations;
using HotelReservation.BusinessLayer.Services.Interfaces;
using HotelReservation.BusinessLayer.VIewModels;
using HotelReservation.DataAccessLayer;
using HotelReservation.DataAccessLayer.DatabaseAccess.Implementations;
using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;

namespace HotelReservation.BusinessLayer.Infrastructure
{
    public class AppContainer
    {
        public AppContainer()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HotelReservationContext>();
            SimpleIoc.Default.Register<IReservationReadAccessor, ReservationReadAccessor>();
            SimpleIoc.Default.Register<IReservationWriteAccessor, ReservationWriteAccessor>();
            SimpleIoc.Default.Register<IReservationReadService, ReservationReadsService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReservationViewModel>();
            SimpleIoc.Default.Register<RoomsViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ReservationViewModel Reservation
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReservationViewModel>();
            }
        }

        public RoomsViewModel Room
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoomsViewModel>();
            }
        }
    }
}
