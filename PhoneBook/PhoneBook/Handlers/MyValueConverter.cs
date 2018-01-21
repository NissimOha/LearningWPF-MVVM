using System;
using System.Windows.Data;
using System.Globalization;
using PhoneBookBL;

namespace PhoneBook
{
    class MyValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Record((string)values[0], (string)values[1], (string)values[2],(string)values[3], (string)values[4], (string)values[5]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
