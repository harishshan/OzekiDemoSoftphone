using System.Windows;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for NatDiscoveryWindow.xaml
    /// </summary>
    public partial class NatDiscoveryWindow : Window
    {
        public NatDiscoveryWindow(Window owner)
        {
            Owner = owner;
            InitializeComponent();
        }
    }
}
