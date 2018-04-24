using System;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.Model.Data
{
    public class MessageSummaryArgs : EventArgs
    {
        public IPhoneLine PhoneLine { get; private set; }
        public MessageSummary MessageSummary { get; private set; }

        public MessageSummaryArgs(IPhoneLine phoneLine, MessageSummary messageSummary)
        {
            PhoneLine = phoneLine;
            MessageSummary = messageSummary;
        }
    }
}
