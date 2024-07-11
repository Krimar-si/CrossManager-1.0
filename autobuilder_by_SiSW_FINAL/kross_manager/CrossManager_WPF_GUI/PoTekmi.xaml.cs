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

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for PoTekmi.xaml
    /// </summary>
    public partial class PoTekmi : Window
    {
        private int globalna_sprememba = 0;
        private string tekmaFilename = "";

        public PoTekmi(string tekmaFilename)
        {
            InitializeComponent();
            this.Title += App.addToTitle();

            this.tekmaFilename = tekmaFilename;
            ((App) App.Current).crossManager.CompetitorLst.Sort();
            lst_tekmovalci.ItemsSource = ((App) App.Current).crossManager.CompetitorLst;
        }

        private void changeRunTimes(int offset)
        {
            
                foreach (Competitor competitor in ((App) App.Current).crossManager.CompetitorLst)
                {
                    int hours = Convert.ToInt32(competitor.RunTime.Substring(0, 2));
                    int minutes = Convert.ToInt32(competitor.RunTime.Substring(3, 2));
                    int seconds = Convert.ToInt32(competitor.RunTime.Substring(6, 2));
                    int millis = Convert.ToInt32(competitor.RunTime.Substring(9, 3));
                    int allseconds = seconds + 60*minutes + 3600*hours;
                    allseconds += offset;

                    hours = allseconds/3600;
                    minutes = (allseconds - hours*3600)/60;
                    seconds = allseconds - minutes*60 - hours*3600;

                    if (seconds<0 || minutes<0 || hours<0)
                    {
                        throw new Exception();
                    }

                    competitor.RunTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                                       hours, minutes, seconds,
                                                       millis);
                }
            
        }

        private void listView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Competitor selectedCompetitor = (Competitor)lst_tekmovalci.SelectedItem;
                UrediTekmovalca urediTekmovalcaWindow = new UrediTekmovalca();
                int idx = ((App) App.Current).crossManager.CompetitorLst.IndexOf(selectedCompetitor);
                urediTekmovalcaWindow.preSetAfterMatch(((App)App.Current).crossManager.CompetitorLst[idx], idx);
                urediTekmovalcaWindow.ShowDialog();
                ((App)App.Current).crossManager.CompetitorLst.Sort();
                lst_tekmovalci.Items.Refresh();
            } catch (Exception e1)
            {
                Console.WriteLine("Ni bil izbran tekmovalec!");
            }
            
        }

        private void btn_shrani_spremembe_Click(object sender, RoutedEventArgs e)
        {
            CrossManager cManager = ((App) App.Current).crossManager;
            XMLHandler.shraniTekmo(tekmaFilename, cManager, cManager.ImeTekme, cManager.StSkupin);
            MessageBox.Show("Tekma je bila shranjena!");
        }

        private void btn_izhod_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ali res želite oditi iz programa? "+System.Environment.NewLine+"*vse neshranjene spremembe bodo izgubljene","Izhod iz programa",MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No,MessageBoxOptions.None);
            if (result.ToString().Equals("Yes"))
            {
                this.Close();
            }
        }

        private void btn_tiskajRezultate(object sender, RoutedEventArgs e)
        {
            TiskanjeRezultatov tiskanjeRezultatov = new TiskanjeRezultatov();
            tiskanjeRezultatov.Show();
            this.Close();
        }

        private void lstView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key.ToString().Equals("Delete") && lst_tekmovalci.SelectedIndex > -1)
                {
                    Competitor competitor = lst_tekmovalci.SelectedItem as Competitor;
                    if (
                        MessageBox.Show(
                            "Ali želite izbrisati tekmovalca/ko " + competitor +
                            " ? ", "Izbris tekmovalca", MessageBoxButton.YesNoCancel, MessageBoxImage.Question,
                            MessageBoxResult.No).ToString().Equals("Yes"))
                    {
                        ((App)App.Current).crossManager.CompetitorLst.Remove(competitor);
                        lst_tekmovalci.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
