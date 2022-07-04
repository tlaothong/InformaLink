using System;
using System.Reactive.Threading.Tasks;
using System.Windows;
using System.Linq;

namespace WpfTestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var client = new InformaLink.Client.InformationLinkClient();
            client.GetInfo().ToObservable().Subscribe(r =>
            {
                Dispatcher.Invoke(() =>
                {
                    r.ForEach(x => listBox.Items.Add(x.Name));
                    MessageBox.Show("Hello?" + r.Count);
                });
            });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // NOT neccessary for production, JUST included for checking result only.
            listBox.Items.Clear();

            // Here we go
            var client = new InformaLink.Client.InformationLinkClient();
            var stationIds = textBox.Text.Trim().Split(',');
            MessageBox.Show($"Query for {stationIds.Length} stations.");
            client.GetInfoByStations(stationIds).ToObservable().Subscribe(r =>
            {
                Dispatcher.Invoke(() =>
                {
                    r.ForEach(x => listBox.Items.Add(x.Name));
                    MessageBox.Show("Hello?" + r.Count);
                });
            });
        }
    }
}
