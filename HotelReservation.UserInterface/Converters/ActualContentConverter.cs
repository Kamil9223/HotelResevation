using HotelReservation.BusinessLayer.Enums;
using HotelReservation.UserInterface.Views;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace HotelReservation.UserInterface.Converters
{
    public class ActualContentConverter : MarkupExtension, IValueConverter
    {
        private static ActualContentConverter pageConverter = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ContentFillOptions)value)
            {
                case ContentFillOptions.Reservations:
                    return new Reservation();
                case ContentFillOptions.Rooms:
                    return new Rooms();
                case ContentFillOptions.ReservationsDetails:
                    return new ReservationDetails();
                case ContentFillOptions.ReservationsList:
                    return new ReservationList();
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return pageConverter ?? (pageConverter = new ActualContentConverter());
        }
    }
}
