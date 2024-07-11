using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using CrossManager_WPF_GUI.Properties;
using Microsoft.Win32;
using PrintingLibrary;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for TiskanjeRezultatov.xaml
    /// </summary>
    public partial class TiskanjeRezultatov : Window
    {
        public TiskanjeRezultatov()
        {
            InitializeComponent();
            this.Title += App.addToTitle();

            List<int> intList = new List<int>();
            intList.Add(1);
            for (int i = 1; i < ((App)App.Current).crossManager.CompetitorLst.Count; i++)
            {
                intList.Add(i+1);
            }
            drpdwn_numberPrinting.ItemsSource = intList;
            if (intList.Count>=3)
            {
                drpdwn_numberPrinting.SelectedIndex = 2;
            }
            else if (((App)App.Current).crossManager.CompetitorLst.Count>0)
            {
                drpdwn_numberPrinting.SelectedIndex = 0;
            }

            radbtn_crossManagerDiploma.IsChecked = true;

            char[] delim = {','};
            string[] diplomas_x = Settings.Default["diplomas_x"].ToString().Split(delim);
            nud_x_imeSole.Text = diplomas_x[0];
            nud_x_imeTekmovalca.Text = diplomas_x[1];
            nud_x_besedilo.Text = diplomas_x[2];
            nud_x_krajDatum.Text = diplomas_x[3];
            nud_x_mentor.Text = diplomas_x[4];
            string[] diplomas_y = Settings.Default["diplomas_y"].ToString().Split(delim);
            nud_y_imeSole.Text = diplomas_y[0];
            nud_y_imeTekmovalca.Text = diplomas_y[1];
            nud_y_besedilo.Text = diplomas_y[2];
            nud_y_krajDatum.Text = diplomas_y[3];
            nud_y_mentor.Text = diplomas_y[4];

            txtbx_krajDatum.Text = Settings.Default["diplomas_kraj"] + ", " + DateTime.Now.Date.ToShortDateString();
            txtbx_mentor.Text = Settings.Default["diplomas_mentor"].ToString();
            txtbx_besedilo.Text = Settings.Default["diplomas_besedilo"].ToString();
        }

        private void porocilo_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.DefaultExt = "pdf";
            fDialog.Filter = "PDF dokumenti (.pdf)|*.pdf";
            if (fDialog.ShowDialog() == true)
            {
                List<string> groupByLst = new List<string>();
                if (chckbx_group_birth_date.IsChecked==true)
                {
                    groupByLst.Add("Leto rojstva");
                }
                if (chckbx_group_grade.IsChecked == true)
                {
                    groupByLst.Add("Razred");
                }
                if (chckbx_group_gender.IsChecked == true)
                {
                    groupByLst.Add("Spol");
                }


                PDFHandler.printReport(App.getOrgName(),
                    ((App)App.Current).crossManager, 
                    fDialog.FileName, 
                    (bool)chckbx_startNumber.IsChecked,
                    (bool)chckbx_gender.IsChecked,
                    (bool)chckbx_birth_date.IsChecked,
                    (bool)chckbx_grade.IsChecked,
                    (bool)chckbx_startGroup.IsChecked,
                    groupByLst);
                Process.Start(fDialog.FileName);
            }
        }

        private void crossManagerDiploma_Checked(object sender, RoutedEventArgs e)
        {
            nud_x_imeSole.Enabled = 
            nud_x_imeTekmovalca.Enabled = 
            nud_x_besedilo.Enabled = 
            nud_x_krajDatum.Enabled = 
            nud_x_mentor.Enabled = 
            nud_y_imeSole.Enabled = 
            nud_y_imeTekmovalca.Enabled = 
            nud_y_besedilo.Enabled = 
            nud_y_krajDatum.Enabled = 
            nud_y_mentor.Enabled = 
            txtbx_krajDatum.IsEnabled = 
            txtbx_mentor.IsEnabled = 
            txtbx_besedilo.IsEnabled = false;
        }



        private void izvoziDiplome_Click(object sender, RoutedEventArgs e)
        {
            
                SaveFileDialog fDialog = new SaveFileDialog();
                fDialog.DefaultExt = "pdf";
                fDialog.Filter = "PDF dokumenti (.pdf)|*.pdf";
                if (fDialog.ShowDialog() == true)
                {
                    int numPrinting = (int) drpdwn_numberPrinting.SelectedValue;

                    if ((bool)radbtn_crossManagerDiploma.IsChecked)
                    {
                        PDFHandler.printCrossDiploma(App.getOrgName(),
                            ((App)App.Current).crossManager,
                            fDialog.FileName,
                            numPrinting);
                    }
                    else
                    {
                        PDFHandler.printCustomDiploma(App.getOrgName(),
                            ((App)App.Current).crossManager,
                            fDialog.FileName,
                            numPrinting,
                            txtbx_besedilo.Text,
                            txtbx_krajDatum.Text,
                            txtbx_mentor.Text,
                            nud_x_imeSole.Value,
                            nud_x_imeTekmovalca.Value,
                            nud_x_besedilo.Value,
                            nud_x_krajDatum.Value,
                            nud_x_mentor.Value,
                            nud_y_imeSole.Value,
                            nud_y_imeTekmovalca.Value,
                            nud_y_besedilo.Value,
                            nud_y_krajDatum.Value,
                            nud_y_mentor.Value);
                    }

                    Process.Start(fDialog.FileName);
                }
            
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
                Settings.Default["diplomas_x"] = nud_x_imeSole.Text + "," + nud_x_imeTekmovalca.Text + "," +
                                                 nud_x_besedilo.Text + "," + nud_x_krajDatum.Text + "," +
                                                 nud_x_mentor.Text + ",";
                Settings.Default["diplomas_y"] = nud_y_imeSole.Text + "," + nud_y_imeTekmovalca.Text + "," +
                                                 nud_y_besedilo.Text + "," + nud_y_krajDatum.Text + "," +
                                                 nud_y_mentor.Text + ",";
                char[] delim = {','};
                Settings.Default["diplomas_kraj"] = txtbx_krajDatum.Text.Split(delim)[0];
                Settings.Default["diplomas_mentor"] = txtbx_mentor.Text;
                Settings.Default["diplomas_besedilo"] = txtbx_besedilo.Text;

                Settings.Default.Save();
           
        }

        private void poljubnaDiploma_Checked(object sender, RoutedEventArgs e)
        {
            nud_x_imeSole.Enabled =
            nud_x_imeTekmovalca.Enabled =
            nud_x_besedilo.Enabled =
            nud_x_krajDatum.Enabled =
            nud_x_mentor.Enabled =
            nud_y_imeSole.Enabled =
            nud_y_imeTekmovalca.Enabled =
            nud_y_besedilo.Enabled =
            nud_y_krajDatum.Enabled =
            nud_y_mentor.Enabled =
            txtbx_krajDatum.IsEnabled =
            txtbx_mentor.IsEnabled =
            txtbx_besedilo.IsEnabled = true;
        }

        private void izhod_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ali res želite oditi iz programa? " + System.Environment.NewLine + "*vse neshranjene spremembe bodo izgubljene", "Izhod iz programa", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.None);
            if (result.ToString().Equals("Yes"))
            {
                this.Close();
            }
        }

        private void zacetek_Click(object sender, RoutedEventArgs e)
        {
            ((App) App.Current).crossManager = null;
            Start start = new Start();
            start.Show();
            this.Close();
        }
    }
}
