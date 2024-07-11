using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrossManager_WPF_GUI.Properties;
using CrossManagerLibrary;
using Microsoft.Win32;
using PrintingLibrary;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for ScannerConfigurator.xaml
    /// </summary>
    public partial class ScannerConfigurator : Window
    {
        private int numberIdx;
        private string scannerInputRegex;
        private bool testRunning = false;
        private int nextNumber = 1;
        private string pressedKeys = "";

        public ScannerConfigurator()
        {
            InitializeComponent();
            this.Title += App.addToTitle();
        }

        private void btn_testBarcodePrint_Click(object sender, RoutedEventArgs e)
        {
            Competitor competitor = new Competitor(1234,"Janez","Novak","m","1.",1,"1987");
            List<Competitor> competitorList = new List<Competitor>();
            competitorList.Add(competitor);
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.DefaultExt = "pdf";
            fDialog.Filter = "PDF dokumenti (.pdf)|*.pdf";
            if (fDialog.ShowDialog() == true)
            {
                PDFHandler.printBars(competitorList, fDialog.FileName, true, "_1xA4");
                Process.Start(fDialog.FileName);
                btn_barcodePrint.IsEnabled = false;
            }
        }



        private void btn_shrani_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["scannerInputRegex"] = scannerInputRegex;
            Settings.Default["scannerIntIdx"] = numberIdx;
            Settings.Default.Save();
            btn_shrani.IsEnabled = false;
            this.Close();
        }

        private void btn_preklici_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_prepareForTesting_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
            testRunning = true;
            btn_prepareForTesting.IsEnabled = false;
        }

        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            e.Handled = true;
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            Keyboard.Focus(this);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (testRunning)
            {
                if (nextNumber==1)
                {
                    string key = e.Key.ToString();
                    numberIdx = key.IndexOf("1");
                    scannerInputRegex = key.Replace("1", "[0-9]");
                    nextNumber++;
                    pressedKeys += " "+e.Key.ToString();
                }
                else if (Regex.IsMatch(e.Key.ToString(), scannerInputRegex))
                {
                    nextNumber++;
                    pressedKeys += ", " + e.Key.ToString();
                }
                else if (nextNumber==5 && e.Key.ToString().Equals("Space"))
                {
                    pressedKeys += ", " + e.Key.ToString();

                    lbl_keysPressed.Content += pressedKeys;
                    lbl_success.Content = "NASTAVITEV USPEŠNA";
                    lbl_success.Background = Brushes.Green;
                    btn_shrani.IsEnabled = true;
                }
                else
                {
                    //ERROR
                    pressedKeys += ", " + e.Key.ToString();

                    lbl_keysPressed.Content = "Pritisnjene tipke: "+pressedKeys;
                    lbl_success.Content = "NASTAVITEV NEUSPEŠNA";
                    lbl_success.Background = Brushes.Red;
                }
            }
            
        }

        private void btn_ponovi_Click(object sender, RoutedEventArgs e)
        {
            btn_barcodePrint.IsEnabled = true;
            btn_prepareForTesting.IsEnabled = true;

            lbl_success.Background = Brushes.Transparent;
            lbl_success.Content = "";
            lbl_keysPressed.Content = "Pritisnjene tipke: ";

            pressedKeys = "";
            
            testRunning = false;
            nextNumber = 1;

        }
    }
}
