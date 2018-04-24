using System;
using System.Globalization;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts IPhoneCall.IsIncoming property to call direction string.
    /// </summary>
    class IncomingToDirectionConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool) value;

            if (val)
                return "IN";

            return "OUT";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;

            if (val == "IN")
                return true;

            return false;
        }

        #endregion
    }
}
