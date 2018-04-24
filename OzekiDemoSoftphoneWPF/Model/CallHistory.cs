using Ozeki.VoIP;
using OzekiDemoSoftphoneWPF.Model.Data;

namespace OzekiDemoSoftphoneWPF.Model
{
    public class CallHistory
    {
        public ObservableList<CallHistoryInfo> List { get; private set; }

        public CallHistory()
        {
            List = new ObservableList<CallHistoryInfo>();
        }

        public void Add(CallHistoryInfo callInfo)
        {
            if (callInfo == null)
                return;

            List.Add(callInfo);
        }

        public void Add(IPhoneCall call)
        {
            if (call == null)
                return;

            List.Add(call.ToPhoneCallInfo());
        }

        public void Remove(CallHistoryInfo callInfo)
        {
            if (callInfo == null)
                return;

            List.Remove(callInfo);
        }

        public void Remove(IPhoneCall call)
        {
            if (call == null)
                return;

            List.Remove(call.ToPhoneCallInfo());
        }

        public void Clear()
        {
            List.Clear();
        }
    }
}
