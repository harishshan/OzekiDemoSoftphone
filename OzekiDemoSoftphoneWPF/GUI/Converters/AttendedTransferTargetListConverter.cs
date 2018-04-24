using System;
using System.Collections.Generic;
using System.Windows.Data;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI.Converters
{
    /// <summary>
    /// Filters the transferee from the phone calls list.
    /// </summary>
    class AttendedTransferTargetListConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<IPhoneCall> calls = values[0] as IEnumerable<IPhoneCall>;
            IPhoneCall transferee = values[1] as IPhoneCall;

            List<IPhoneCall> newList = new List<IPhoneCall>();
            foreach (var call in calls)
            {
                if (call.Equals(transferee))
                    continue;

                newList.Add(call);
            }


            return newList;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
