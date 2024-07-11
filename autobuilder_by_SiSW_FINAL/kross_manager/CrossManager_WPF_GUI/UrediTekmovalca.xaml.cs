using System;
using System.Collections.Generic;
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
using CrossManagerLibrary;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for UrediTekmovalca.xaml
    /// </summary>
    public partial class UrediTekmovalca : Window
    {
        private bool editingCompetitor = false;
        private int competitorLstIdx;

        public UrediTekmovalca()
        {
            InitializeComponent();
            this.Title += App.addToTitle();

            lbl_ID.Content = ((App) App.Current).crossManager.NextCompetitorID;
        }

        internal void preSet(CrossManagerLibrary.Competitor competitor, int competitorLstIdx)
        {
            this.editingCompetitor = true;
            this.competitorLstIdx = competitorLstIdx;
            lbl_ID.Content = competitor.ID;
            txtbx_FName.Text = competitor.First_name;
            txtbx_LName.Text = competitor.Last_name;
            if (competitor.Gender.StartsWith("M"))
            {
                cmbbx_Gender.SelectedIndex = 0;
            }
            else
            {
                cmbbx_Gender.SelectedIndex = 1;
            }
            txtbx_BirthDate.Text = competitor.Birth_date;
            txtbx_StartGroup.Text = competitor.Start_group.ToString();
            txtbx_Grade.Text = competitor.Grade;
        }

        private bool shrani()
        {
            if (validateForm())
            {

                Competitor competitor = new Competitor((int) lbl_ID.Content,
                                                       txtbx_FName.Text,
                                                       txtbx_LName.Text,
                                                       cmbbx_Gender.Text,
                                                       txtbx_Grade.Text,
                                                       Convert.ToInt32(txtbx_StartGroup.Text),
                                                       txtbx_BirthDate.Text);
                
                if (editingCompetitor)
                {
                    competitor.RunTime = txtbx_RunTime.Text;
                    ((App) App.Current).crossManager.CompetitorLst[this.competitorLstIdx] = competitor;
                }
                else
                {
                    ((App) App.Current).crossManager.addCompetitor(competitor);
                }
                return true;
            } 
            else
            {
                return false;
            }
        }

        private void shraniInDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (shrani())
            {
                this.editingCompetitor = false;
                lbl_ID.Content = ((App) App.Current).crossManager.NextCompetitorID;
                txtbx_FName.Text = "";
                txtbx_LName.Text = "";
                cmbbx_Gender.Text = "";
                txtbx_BirthDate.Text = "";
                txtbx_StartGroup.Text = "";
                txtbx_Grade.Text = "";
                cmbbx_Gender.SelectedIndex = 0;
            }
        }

        private void shrani_Click(object sender, RoutedEventArgs e)
        {
            if (shrani())
            {
                this.Close();
            }
        }

        private void preklici_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void preSetAfterMatch(Competitor competitor, int idx)
        {
            preSet(competitor,idx);
            btn_shraniInDodNov.Visibility = Visibility.Hidden;
            lbl_runTime.Visibility = Visibility.Visible;
            txtbx_RunTime.Visibility = Visibility.Visible;
            txtbx_RunTime.Text = competitor.RunTime;
        }

        private bool validateForm()
        {
            bool validatedSuccess = true;

            try
            {
                Convert.ToInt32(txtbx_StartGroup.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startna skupina mora biti celo število!");
                validatedSuccess = false;
            }

            if (txtbx_RunTime.Visibility == Visibility.Visible)
            {
                if (!Regex.IsMatch(txtbx_RunTime.Text, "[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9][0-9]") ||
                    txtbx_RunTime.Text.Length != 12)
                {
                    MessageBox.Show("Čas teka mora biti tipa: 00:00:00.000 !");
                    validatedSuccess = false;
                }
            }

            if (!Regex.IsMatch(txtbx_BirthDate.Text, "[0-9][0-9][0-9][0-9]"))
            {
                    MessageBox.Show("Leto rojstva mora biti tipa: YYYY !");
                    validatedSuccess = false;
            }
            

            return validatedSuccess;
        }
    }
}
