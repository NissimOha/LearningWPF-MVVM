using LoginProjectBL;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace LoginProject
{
    public class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new User((string)values[0], (string)values[1], (string)values[2], (string)values[3],
                (string)values[4], (string)values[5], (string)values[6], (string)values[7]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
