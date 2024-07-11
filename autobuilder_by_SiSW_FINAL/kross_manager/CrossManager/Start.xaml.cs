using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrossManagerGUI.Properties;

namespace CrossManagerGUI
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void novaTekma_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new PripravaTekme();
            this.Close();
            Application.Current.MainWindow.Show();
        }

    }
}
