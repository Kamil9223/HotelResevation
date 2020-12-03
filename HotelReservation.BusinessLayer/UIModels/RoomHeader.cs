using HotelReservation.BusinessLayer.Enums;

namespace HotelReservation.BusinessLayer.UIModels
{
    public class RoomHeader
    {
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public byte NumberOfPlaces { get; set; }
        public decimal PricePerNight { get; set; }


    }
}
