using HotelReservation.DataAccessLayer.Models;

namespace HotelReservation.BusinessLayer.UIModels
{
    public class RoomInformation
    {
        public int RoomNumber { get; set; }
        public byte Floor { get; set; }
        public RoomType RoomType { get; set; }
        public byte Area { get; set; }
        public byte NumberOfPlaces { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsOccupiedNow { get; set; }
    }
}
