using System.Collections.Generic;
using System.Windows;
using Ozeki.Network;
using Ozeki.VoIP;
using OzekiDemoSoftphoneWPF.GUI.GUIModels;
using Ozeki.Common;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountModel Model { get; set; }
        public List<NatTraversalMethod> NatTraversalMethods { get; private set; }
        public List<TransportType> TransportTypes { get; private set; }
        public List<SRTPMode> SRTPModes { get; private set; }

        public AccountWindow(Window owner, AccountModel model)
        {
            Model = model;
            InitLists();
            Owner = owner;
            InitializeComponent();
        }

        private void InitLists()
        {
            NatTraversalMethods = new List<NatTraversalMethod>();
            NatTraversalMethods.Add(NatTraversalMethod.None);
            NatTraversalMethods.Add(NatTraversalMethod.STUN);
            NatTraversalMethods.Add(NatTraversalMethod.TURN);

            TransportTypes = new List<TransportType>();
            TransportTypes.Add(TransportType.Udp);
            TransportTypes.Add(TransportType.Tcp);
            TransportTypes.Add(TransportType.Tls);

            SRTPModes = new List<SRTPMode>();
            SRTPModes.Add(SRTPMode.None);
            SRTPModes.Add(SRTPMode.Prefer);
            SRTPModes.Add(SRTPMode.Force);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate("User name", Model.UserName))
                return;

            if (!Validate("Register name", Model.RegisterName))
                return;

            if (!Validate("Domain", Model.Domain))
                return;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool Validate(string propertyName, string value)
        {
            if (value == null || string.IsNullOrEmpty(value.Trim()))
            {
                MessageBox.Show(string.Format("{0} cannot be empty!", propertyName));
                return false;
            }

            return true;
        }
    }
}
