using System;
using System.Collections.Generic;
using System.Windows.Data;
using Ozeki.Media;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class ResolutionListConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<VideoCapabilities> list = value as List<VideoCapabilities>;

            List<string> newList = new List<string>();

            foreach (var item in list)
            {
                VideoCapabilities cap = item as VideoCapabilities;
                if (cap == null)
                    return string.Empty;

                newList.Add(string.Format("{0}x{1}", item.Resolution.Width, item.Resolution.Height));
            }

            return newList;
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
