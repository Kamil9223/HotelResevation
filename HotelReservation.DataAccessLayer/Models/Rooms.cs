using System;
using System.Collections.Generic;

namespace HotelReservation.DataAccessLayer.Models
{
    public class Rooms
    {
        public int RoomNumber { get; private set; }
        public byte Floor { get; private set; }
        public RoomType RoomType { get; private set; }
        public byte Area { get; private set; }
        public byte NumberOfPlaces { get; private set; }
        public decimal PricePerNight { get; private set; }

        public virtual ICollection<Reservations> Reservations { get; private set; }

        public Rooms()
        {
            Reservations = new HashSet<Reservations>();
        }

        public Rooms(int roomNumber, byte floor, RoomType roomType, byte area, byte numberOfPlaces, decimal pricePerNight)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            RoomType = roomType;
            Area = area;
            NumberOfPlaces = numberOfPlaces;
            PricePerNight = pricePerNight;
        }
    }

    public enum RoomType { RoomWithKitchen, Apartament }
}
