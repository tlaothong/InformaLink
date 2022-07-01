﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive;
using System.Reactive.Threading.Tasks;

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
