using System;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts the ringtone file name value to string. If no ringtone file set then returns the default value.
    /// </summary>
    class RingtoneToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "Default";

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
