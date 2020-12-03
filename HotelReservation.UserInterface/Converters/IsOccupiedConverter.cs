using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelReservation.UserInterface.Converters
{
    public class IsOccupiedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value
                ? "Zajęty"
                : "Wolny";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
