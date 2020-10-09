using System;

namespace HotelReservation.BusinessLayer.UIModels
{
    public class ReservationDetails
    {
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte NumberOfPeople { get; set; }
        public byte NumberOfPlaces { get; set; }
        public int RoomNumber { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
