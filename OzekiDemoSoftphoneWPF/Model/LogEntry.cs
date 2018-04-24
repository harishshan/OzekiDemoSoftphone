using Ozeki.Common;
using System;

namespace OzekiDemoSoftphoneWPF.Model
{
    public class LogEntry
    {
        public DateTime DateTime { get; set; }

        public LogLevel LogLevel { get; set; }

        public int Index { get; set; }

        public string Message { get; set; }
    }
}
