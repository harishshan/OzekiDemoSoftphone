using System.Windows;
using Ozeki.VoIP;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for MessageSummaryWindow.xaml
    /// </summary>
    public partial class MessageSummaryWindow : Window
    {
        public MessageSummary MessageSummary
        {
            get;
            private set;
        }

        public MessageSummaryWindow(Window owner, MessageSummary messageSummary)
        {
            Owner = owner;
            MessageSummary = messageSummary;

            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
