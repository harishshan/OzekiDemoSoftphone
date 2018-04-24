using System;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts an IPhoneLine object to a string.
    /// </summary>
    class MessageSummaryToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IPhoneLine line = value as IPhoneLine;
            if (line == null)
                return "No lines selected";

            var messageSummary = line.Subscription.Get(SIPEventType.MessageSummary);
            if (messageSummary == null)
                return "No message info";

            return "View messages";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
