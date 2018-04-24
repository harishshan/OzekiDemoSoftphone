using System;
using System.Windows.Data;
using Ozeki.Media;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class ResolutionConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Resolution res = value as Resolution;

            return string.Format("{0}x{1}", res.Width, res.Height);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (string)value;

            string[] tokens = val.Split('x');

            int width;
            int.TryParse(tokens[0], out width);

            int height;
            int.TryParse(tokens[1], out height);

            return new Resolution(width, height);
        }

        #endregion
    }
}