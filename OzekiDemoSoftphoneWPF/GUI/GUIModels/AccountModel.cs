using Ozeki.VoIP;
using Ozeki.Network;
using Ozeki.Common;

namespace OzekiDemoSoftphoneWPF.GUI.GUIModels
{
    public class AccountModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string RegisterName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string OutboundProxy { get; set; }
        public bool RegistrationRequired { get; set; }

        public TransportType TransportType { get; set; }
        public SRTPMode SRTPMode { get; set; }
        
        public bool AutoDetectNat { get; set; }
        public NatTraversalMethod NatTraversalMethod { get; set; }
        public string STUNServerAddress { get; set; }

        public SIPAccount SIPAccount
        {
            get { return new SIPAccount(RegistrationRequired, DisplayName, UserName, RegisterName, Password, Domain, OutboundProxy); }
        }

        public NatConfiguration NatConfig
        {
            get
            {
                return new NatConfiguration(NatTraversalMethod, STUNServerAddress, AutoDetectNat);
            }
        }

        public AccountModel()
        {
            DisplayName = string.Empty;
            UserName = string.Empty;
            RegisterName = string.Empty;
            Password = string.Empty;
            Domain = string.Empty;
            OutboundProxy = string.Empty;
            RegistrationRequired = true;

            TransportType = TransportType.Udp;
            SRTPMode = SRTPMode.None;
            NatTraversalMethod = NatTraversalMethod.STUN;
            AutoDetectNat = true;
        }
    }
}
