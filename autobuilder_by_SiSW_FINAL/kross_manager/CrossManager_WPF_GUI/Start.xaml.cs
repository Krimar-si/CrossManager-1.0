using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using CrossManager_WPF_GUI.Properties;
using CrossManagerLibrary;
using InputLibrary;
using Microsoft.Win32;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
            this.Title += App.addToTitle();
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

        private void nadaljevanjeTekme_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.DefaultExt = "cross";
            fDialog.Filter = "CrossManager datoteke (.cross)|*.cross";
            if (fDialog.ShowDialog() == true)
            {
                string imeTekme;
                int steviloSkupin;
                CrossManager crossManager = null;
                
                XMLHandler.odpriTekmo(fDialog.FileName, ref crossManager, out imeTekme, out steviloSkupin);

                PripravaTekme pripravaTekme = new PripravaTekme(crossManager,imeTekme,steviloSkupin,fDialog.FileName);
                pripravaTekme.Show();
                this.Close();
            }
        }

        private void mn_configure_scanner_Click(object sender, RoutedEventArgs e)
        {
            ScannerConfigurator scannerKonfigurator = new ScannerConfigurator();
            scannerKonfigurator.ShowDialog();
        }

        private void btn_porocilo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.DefaultExt = "cross";
            fDialog.Filter = "CrossManager datoteke (.cross)|*.cross";
            if (fDialog.ShowDialog() == true)
            {
                string imeTekme;
                int steviloSkupin;
                CrossManager crossManager = null;

                XMLHandler.odpriTekmo(fDialog.FileName, ref crossManager, out imeTekme, out steviloSkupin);

                crossManager.ImeTekme = imeTekme;
                crossManager.StSkupin = steviloSkupin;
                ((App) App.Current).crossManager = crossManager;
                PoTekmi poTekmi = new PoTekmi(fDialog.FileName);
                poTekmi.Show();
                this.Close();
            }
        }

        private void vizitka_Click(object sender, RoutedEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(".\\Pomoc\\pomoc.pdf");
        }

        private void rez_vec_tekem_Click(object sender, RoutedEventArgs e)
        {
            VecTekem vecTekem = new VecTekem();
            vecTekem.Show();
            this.Close();
        }

        private void video_Click1(object sender, RoutedEventArgs e)
        {
            Process.Start(".\\Pomoc\\01_Predstavitev_citalca.divx");
        }
        private void video_Click2(object sender, RoutedEventArgs e)
        {
            Process.Start(".\\Pomoc\\02_Priprava_tekme.divx");
        }
        private void video_Click3(object sender, RoutedEventArgs e)
        {
            Process.Start(".\\Pomoc\\03_Tekma.divx");
        }
        private void video_Click4(object sender, RoutedEventArgs e)
        {
            Process.Start(".\\Pomoc\\04_Po_tekmi.divx");
        }
    }
}
