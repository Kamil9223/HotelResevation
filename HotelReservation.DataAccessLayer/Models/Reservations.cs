using System;

namespace HotelReservation.DataAccessLayer.Models
{
    public class Reservations
    {
        public int ReservationId { get; private set; }
        public byte NumberOfPeople { get; private set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public int GuestId { get; set; }
        public int RoomNumber { get; set; }

        public virtual Guests Guest { get; private set; }
        public virtual Rooms Room { get; private set; }

        public Reservations()
        { 
        }

        public Reservations(byte numberOfPeople, DateTime dateFrom, DateTime dateTo, Guests guest, Rooms room)
        {
            NumberOfPeople = numberOfPeople;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Guest = guest;
            Room = room;
        }
    }
}
