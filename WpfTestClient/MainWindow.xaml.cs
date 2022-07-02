using System;
using System.Reactive.Threading.Tasks;
using System.Windows;

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
    }
}
