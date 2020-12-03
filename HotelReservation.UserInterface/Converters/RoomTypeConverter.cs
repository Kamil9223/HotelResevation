using HotelReservation.BusinessLayer.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelReservation.UserInterface.Converters
{
    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((RoomType)value)
            {
                case RoomType.Apartament:
                    return "Apartament";
                case RoomType.RoomWithKitchen:
                    return "Pokój z kuchnią";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
