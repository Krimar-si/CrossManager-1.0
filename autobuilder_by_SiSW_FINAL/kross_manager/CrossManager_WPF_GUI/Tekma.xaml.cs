using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using CrossManager_WPF_GUI.Properties;
using CrossManagerLibrary;
using Brushes=System.Windows.Media.Brushes;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Tekma : Window
    {
        CrossStopWatch stopWatch = new CrossStopWatch();
        private Thread t = null;

        private List<Competitor> tekmovalci_unfinished;
        private int finishedCompetitorNumber;
        private bool tekmaRunning = false;
        private int stSkupine;
        private string tekmaFilename; 

        private string scannerInput = (string) Settings.Default["scannerInputRegex"];//"D[0-9]" -default
        private int scannerInputNumIdx = (int) Settings.Default["scannerIntIdx"];  //1 - default

        /*protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            e.Handled = true;
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            Keyboard.Focus(this);
        }*/

        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool error = false;
            if (tekmaRunning)
            {
            
            lbl_tekmovalecFinished.Background = Brushes.Transparent;
            if (Regex.IsMatch(e.Key.ToString(), scannerInput))
            {
                finishedCompetitorNumber *= 10;
                finishedCompetitorNumber += Convert.ToInt32(e.Key.ToString().Substring(scannerInputNumIdx,1));
                lbl_tekmovalecFinished.Content = finishedCompetitorNumber;
            }
            else if (Regex.IsMatch(e.Key.ToString(), "NumPad[0-9]"))
            {
                finishedCompetitorNumber *= 10;
                try
                {
                    finishedCompetitorNumber += Convert.ToInt32(e.Key.ToString().Substring(6, 1));
                } catch (Exception ex){}
                lbl_tekmovalecFinished.Content = finishedCompetitorNumber;
            }
            else if (Regex.IsMatch(e.Key.ToString(), "[0-9]"))
            {
                        finishedCompetitorNumber *= 10;
                        try
                        {
                            finishedCompetitorNumber += Convert.ToInt32(e.Key.ToString());
                        } catch (Exception ex){}
                        lbl_tekmovalecFinished.Content = finishedCompetitorNumber;
            }
            else
            {
                switch (e.Key.ToString())
                {
                    case "Return":
                    case "Space":
                        tekmovalec_finished_action();
                        finishedCompetitorNumber = 0;
                        break;
                    case "Back":
                        finishedCompetitorNumber /= 10;
                        lbl_tekmovalecFinished.Content = finishedCompetitorNumber;
                        break;
                }
            }
            }

            /*
            if (error)
            {
                MessageBox.Show(
                    "Zgodila se je napaka pri branju tipke." + System.Environment.NewLine +
                    "Prosim ponovno zaženite konfiguracijo.", "Napačna tipka", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                this.Close();
            }*/
        }

        private void tekmovalec_finished_action()
        {
            string runTime = stopWatch.Text;
            Competitor dummyCompetitor = new Competitor(finishedCompetitorNumber);
            //remove from tekmovalci_unfinished
            if (tekmovalci_unfinished.Remove(dummyCompetitor))
            {
                lst_tekmovalci_unfinished.Items.Refresh();

                //update in crossmanager tekmovalci list
                int idx = ((App)App.Current).crossManager.CompetitorLst.IndexOf(dummyCompetitor);
                Competitor mainCompetitor = ((App)App.Current).crossManager.CompetitorLst[idx];
                mainCompetitor.RunTime = runTime;

                lbl_tekmovalecFinished.Content = mainCompetitor.First_name + " " + mainCompetitor.Last_name + " - " +
                                                 mainCompetitor.RunTime;
                lbl_tekmovalecFinished.Background = Brushes.Green;
            }
            else
            {
                lbl_tekmovalecFinished.Content = "NAPAČEN VNOS !";
                lbl_tekmovalecFinished.Background = Brushes.Red;
            }
            
            if (tekmovalci_unfinished.Count==0)
            {
                startButton.IsEnabled = false;
                btn_naprej.IsEnabled = true;
                tekmaRunning = false;
                ustavi_stoparico();
            }
        }


        public Tekma(int stSkupine, string tekmaFilename)
        {
            InitializeComponent();
            this.Title += App.addToTitle();

            this.stSkupine = stSkupine;
            uredi_lst_tekmovalci();

            this.tekmaFilename = tekmaFilename;
            grpbx_tekmovanje.Header += stSkupine + "/" + ((App) App.Current).crossManager.StSkupin;

        }


        private void zazeni_stoparico()
        {
            stopWatch.Start();
            stopWatchTxtBlck.DataContext = stopWatch;
            t = new Thread(new ThreadStart(this.makeStopWatchChangeEvent));
            t.Start();



            
            while (stopWatchTxtBlck.ActualWidth<this.ActualWidth-50)
            {
                stopWatchTxtBlck.FontSize++;
                stopWatchTxtBlck.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                stopWatchTxtBlck.Arrange(new Rect(stopWatchTxtBlck.DesiredSize));
            }
            stopWatchTxtBlck.FontSize--;
        }


        private void ustavi_stoparico()
        {
            if (t != null)
            {
                t.Abort();
            }
        }

        private void uredi_lst_tekmovalci()
        {
            this.tekmovalci_unfinished = new List<Competitor>();
            foreach (Competitor competitor in ((App)App.Current).crossManager.CompetitorLst)
            {
                if (this.stSkupine == competitor.Start_group)
                {
                    tekmovalci_unfinished.Add(competitor);
                }
            }
            lst_tekmovalci_unfinished.ItemsSource = tekmovalci_unfinished;
            this.finishedCompetitorNumber = 0;
        }
        public void makeStopWatchChangeEvent()
        {
            while (true)
            {
                Thread.Sleep(100);
                stopWatch.OnPropertyChanged(new PropertyChangedEventArgs("Text"));   
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ustavi_stoparico();
        }


        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (tekmaRunning)
            {
                MessageBoxResult result = MessageBox.Show("Ali res želite prekiniti tekmo trenutne skupine?", "Prekinitev tekme trenutne skupine", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.None);
                if (result.ToString().Equals("Yes"))
                {
                    ustavi_stoparico();
                    stopWatch = new CrossStopWatch();
                    uredi_lst_tekmovalci();
                    tekmaRunning = false;
                    startButton.Content = "Začni tekmo skupine";

                    lbl_tekmovalecFinished.Content = "";
                    lbl_tekmovalecFinished.Background = Brushes.Transparent;
                    

                    btn_nazaj_IsEnabledSetter();
                }
            }
            else
            {
                uredi_lst_tekmovalci();
                zazeni_stoparico();
                tekmaRunning = true;
                startButton.Content = "Prekini tekmo skupine";

                btn_nazaj.IsEnabled = false;
            }
        }

        private void btn_nazaj_Click(object sender, RoutedEventArgs e)
        {
            PripravaTekme pripravaTekme = new PripravaTekme(((App)App.Current).crossManager,
                ((App)App.Current).crossManager.ImeTekme,
                ((App)App.Current).crossManager.StSkupin, tekmaFilename);
            pripravaTekme.Show();
            this.Close();
        }

        private void btn_naprej_Click(object sender, RoutedEventArgs e)
        {
            if (stSkupine<((App)App.Current).crossManager.StSkupin)
            {
                Tekma tekma = new Tekma(stSkupine+1, tekmaFilename);
                tekma.Show();
                this.Close();
            } else
            {
                CrossManager cManager = ((App) App.Current).crossManager;
                XMLHandler.shraniTekmo(tekmaFilename, cManager, cManager.ImeTekme,cManager.StSkupin);
                MessageBox.Show("Tekma je bila shranjena!");
                PoTekmi poTekmi = new PoTekmi(tekmaFilename);
                poTekmi.Show();
                this.Close();
            }
        }

        private void btn_nazaj_IsEnabledSetter()
        {
            if (stSkupine == 1)
            {
                btn_nazaj.IsEnabled = true;
            }
            else
            {
                btn_nazaj.IsEnabled = false;
            }
        }

        private void btn_nazaj_Loaded(object sender, RoutedEventArgs e)
        {
            btn_nazaj_IsEnabledSetter();
        }

        private void btn_naprej_Loaded(object sender, RoutedEventArgs e)
        {
            btn_naprej.IsEnabled = false;
            if (stSkupine==((App)App.Current).crossManager.StSkupin)
            {
                btn_naprej.Content = "Konec tekme";
            }
        }


    }

}
