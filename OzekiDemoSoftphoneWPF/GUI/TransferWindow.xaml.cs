using System.Windows;
using OzekiDemoSoftphoneWPF.GUI.GUIModels;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        public TransferModel Model { get; set; }

        public TransferWindow(Window owner, TransferModel model)
        {
            Owner = owner;
            Model = model;
            InitializeComponent();
        }

        private void btnBlindTransfer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
