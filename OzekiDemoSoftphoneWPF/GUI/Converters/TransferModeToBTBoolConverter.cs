using System;
using System.Windows.Data;
using OzekiDemoSoftphoneWPF.Model.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts transfer mode to bool. If the transfer mode is blind transfer then returns true.
    /// </summary>
    class TransferModeToBTBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TransferMode transferMode = (TransferMode)value;
            if (transferMode == TransferMode.Blind)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return TransferMode.Blind;

            return TransferMode.Attended;
        }

        #endregion
    }
}
