using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class SupportedMediaTypesToCallTypeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<Ozeki.Media.MediaType> types = value as IEnumerable<Ozeki.Media.MediaType>;

            if (types.Contains(Ozeki.Media.MediaType.Audio) && types.Contains(Ozeki.Media.MediaType.Video))
                return CallType.AudioVideo;

            if (!types.Contains(Ozeki.Media.MediaType.Audio) && types.Contains(Ozeki.Media.MediaType.Video))
                return CallType.Video;
            
            return CallType.Audio;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion

    }
}
