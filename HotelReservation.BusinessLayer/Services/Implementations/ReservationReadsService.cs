using HotelReservation.BusinessLayer.Services.Interfaces;
using HotelReservation.BusinessLayer.UIModels;
using HotelReservation.DataAccessLayer.DatabaseAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.BusinessLayer.Services.Implementations
{
    public class ReservationReadsService : IReservationReadService
    {
        private readonly IReservationReadAccessor _reservationReader;

        public ReservationReadsService(IReservationReadAccessor reservationReader)
        {
            _reservationReader = reservationReader;
        }

        public async Task<IEnumerable<ReservationHeader>> GetReservationsHeaders()
        {
            var reservations = await _reservationReader.GetAllReservations();
            var reservationsHeaders = new List<ReservationHeader>();

            foreach(var reservation in reservations)
            {
                reservationsHeaders.Add(new ReservationHeader
                {
                    ReservationId = reservation.ReservationId,
                    RoomNumber = reservation.Room.RoomNumber,
                    DateFrom = reservation.DateFrom,
                    DateTo = reservation.DateTo
                });
            }

            return reservationsHeaders;
        }

        public async Task<ReservationDetails> GetReservationDetail(int reservationId)
        {
            var details = await _reservationReader.GetReservation(reservationId);

            if (details == null) ;
            //TODO: obsługa wyjątków

            //TODO: można użyć automappera
            var reservationDetails = new ReservationDetails
            {
                RoomNumber = details.RoomNumber,
                DateFrom = details.DateFrom,
                DateTo = details.DateTo,
                Email = details.Guest.Email,
                GuestName = details.Guest.Name,
                GuestSurname = details.Guest.Surname,
                NumberOfPeople = details.NumberOfPeople,
                NumberOfPlaces = details.Room.NumberOfPlaces,
                PhoneNumber = details.Guest.Phone
            };

            return reservationDetails;
        }
    }
}
