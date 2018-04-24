using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts a list of integer frame rate values to string. (0 value == Max frame rate)
    /// </summary>
    class FrameRateListToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<int> intValues = value as List<int>;
            List<string> stringValues = new List<string>();
            
            foreach (var val in intValues)
            {
                if (val == 0)
                    stringValues.Add(FrameRateToStringConverter.MaxValue);
                else
                    stringValues.Add(val.ToString());
            }

            return stringValues;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
