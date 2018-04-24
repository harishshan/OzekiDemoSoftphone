using System;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class ReverseBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return !val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return !val;
        }

        #endregion
    }
}
