using System;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts an integer frame rate value to a string. (0 = Maximum frame rate)
    /// </summary>
    class FrameRateToStringConverter : IValueConverter
    {
        public static string MaxValue = "Max";

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = (int)value;
            if (val == 0)
                return MaxValue;

            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;
            if (val == MaxValue)
                return 0;

            return val;
        }

        #endregion
    }
}
