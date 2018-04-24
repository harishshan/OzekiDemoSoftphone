using System;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class MessageSummaryToBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IPhoneLine line = value as IPhoneLine;
            if (line == null)
                return false;

            var messageSummary = line.Subscription.Get(SIPEventType.MessageSummary);
            if (messageSummary == null)
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
