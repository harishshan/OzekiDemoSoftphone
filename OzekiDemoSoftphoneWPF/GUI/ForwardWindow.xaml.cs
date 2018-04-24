using System.Windows;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for ForwardWindow.xaml
    /// </summary>
    public partial class ForwardWindow : Window
    {
        public string Target { get; set;}

        public ForwardWindow(Window owner)
        {
            Owner = owner;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
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
