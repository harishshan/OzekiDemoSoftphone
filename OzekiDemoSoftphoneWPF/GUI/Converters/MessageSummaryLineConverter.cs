using System;
using System.Collections.Generic;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    class MessageSummaryLineConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<MessageSummaryLine> summaryLines = value as List<MessageSummaryLine>;
            if (summaryLines == null)
                return value;

            List<string> newList = new List<string>();
            foreach (var line in summaryLines)
            {
                string stringData = string.Format("Type: {0}; New messages: {1}; Old messages: {2}", line.MessageContextClass, line.NewMessages, line.OldMessages);
                newList.Add(stringData);
            }

            return newList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
