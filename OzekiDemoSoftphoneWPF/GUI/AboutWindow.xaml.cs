using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public string Copyright { get; private set; }

        public AboutWindow(Window owner)
        {
            Owner = owner;
            Copyright = "© Copyright 2000-" + DateTime.Now.Year + ". Ozeki Informatics Ltd. All rights reserved.";
            InitializeComponent();
            textBlockVersion.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://www.voip-sip-sdk.com/");
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private void email_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("mailto:info@voip-sip-sdk.com")); e.Handled = true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

        }
    }
}
