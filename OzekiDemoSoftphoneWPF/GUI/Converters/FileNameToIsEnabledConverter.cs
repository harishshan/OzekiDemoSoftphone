using System;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts a string to bool. Used for audio playback/record buttons.
    /// </summary>
    class FileNameToIsEnabledConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;
            if (string.IsNullOrEmpty(val))
                return false;

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
