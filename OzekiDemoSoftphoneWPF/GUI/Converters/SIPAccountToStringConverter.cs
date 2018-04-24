using System;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Converts SIP Account to string (example: 1001@192.168.111.100)
    /// </summary>
    class SIPAccountToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SIPAccount account = value as SIPAccount;
            if (account == null)
                return value;

            return string.Format("{0}@{1}", account.UserName, account.DomainServerHost);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
