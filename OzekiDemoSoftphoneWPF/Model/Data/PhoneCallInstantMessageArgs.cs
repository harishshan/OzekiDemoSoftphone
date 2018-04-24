using Ozeki.VoIP;
using System;

namespace OzekiDemoSoftphoneWPF.Model.Data
{
    public class PhoneCallInstantMessageArgs : EventArgs
    {
        public IPhoneCall PhoneCall { get; private set; }
        public InstantMessage Message { get; private set; }

        public PhoneCallInstantMessageArgs(IPhoneCall phoneCall, InstantMessage message)
        {
            PhoneCall = phoneCall;
            Message = message;
        }
    }
}
