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
using CrossManagerLibrary;
using Microsoft.Win32;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for VecTekem.xaml
    /// </summary>
    public partial class VecTekem : Window
    {
        public VecTekem()
        {
            InitializeComponent();
            this.Title += App.addToTitle();
            txtbx_tekmaName.Text = "Skupno tekmovanje v krosu " + DateTime.Now.Date.ToShortDateString();
        }

        private void preklici_Click(object sender, RoutedEventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Close();
        }

        private void zdruzi_Click(object sender, RoutedEventArgs e)
        {
            string tekmaFilename = null;
            CrossManager crossManager = new CrossManager();
            crossManager.ImeTekme = txtbx_tekmaName.Text;

            for (int i=0; i < stZdruzitev.Value; i++)
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.DefaultExt = "cross";
                fDialog.Filter = "CrossManager datoteke (.cross)|*.cross";
                if (fDialog.ShowDialog() == true)
                {
                    string x;
                    int y;
                    CrossManager crossManagerTemp = null;
                    XMLHandler.odpriTekmo(fDialog.FileName, ref crossManagerTemp, out x, out y);
                    crossManager.addCompetitors(crossManagerTemp.CompetitorLst);

                } else
                {
                    i--;
                }
            }

            bool result = false;
            while (!result)
            {
                SaveFileDialog fDialog = new SaveFileDialog();
                fDialog.DefaultExt = "cross";
                fDialog.Filter = "CrossManager datoteke (.cross)|*.cross";
                fDialog.FileName = crossManager.ImeTekme;
                if (fDialog.ShowDialog() == true)
                {
                    result = XMLHandler.shraniTekmo(fDialog.FileName, crossManager,
                                                    crossManager.ImeTekme,
                                                    crossManager.NextCompetitorID);
                    tekmaFilename = fDialog.FileName;
                }
                else
                {
                    result = false;
                }
            }


            ((App)App.Current).crossManager = crossManager;
            PoTekmi poTekmi = new PoTekmi(tekmaFilename);
            poTekmi.Show();
            this.Close();
        }
    }
}
