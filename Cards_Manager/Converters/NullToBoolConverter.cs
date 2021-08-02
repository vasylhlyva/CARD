using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cards_Manager.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return value != null && value.GetType() == parameter;
            }
            else
            {
                return value != null;
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}