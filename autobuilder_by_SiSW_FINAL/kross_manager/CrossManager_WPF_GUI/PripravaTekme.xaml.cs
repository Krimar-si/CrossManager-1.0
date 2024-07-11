using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrossManagerLibrary;
using PrintingLibrary;
using InputLibrary;
using KeyEventArgs=System.Windows.Input.KeyEventArgs;
using MessageBox=System.Windows.MessageBox;
using MessageBoxOptions=System.Windows.MessageBoxOptions;
using OpenFileDialog=Microsoft.Win32.OpenFileDialog;
using RadioButton=System.Windows.Controls.RadioButton;
using SaveFileDialog=Microsoft.Win32.SaveFileDialog;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for PripravaTekme.xaml
    /// </summary>
    public partial class PripravaTekme : Window
    {
        private string tekmaFilename = "";

        public PripravaTekme()
        {
            InitializeComponent();
            this.Title += App.addToTitle();
            nud_stSkupin.Minimum = 1;

            App curApp = (App)App.Current;
            curApp.crossManager = new CrossManager();
            lst_tekmovalci.ItemsSource = curApp.crossManager.CompetitorLst;
            txtbx_tekmaName.Text = "Tekmovanje v krosu "+DateTime.Now.Date.ToShortDateString();

            
        }
         public PripravaTekme(CrossManager crossManager, string imeTekme, int stSkupin, string tekmaFilename)
         {
             InitializeComponent();
             this.Title += App.addToTitle();
             nud_stSkupin.Minimum = 1;

             this.tekmaFilename = tekmaFilename;
             App curApp = (App)App.Current;
             curApp.crossManager = crossManager;
             lst_tekmovalci.ItemsSource = curApp.crossManager.CompetitorLst;
             txtbx_tekmaName.Text = imeTekme;
             nud_stSkupin.Value = stSkupin;
         }


        private void natisniTekmovalce_Click(object sender, RoutedEventArgs e)
        {
            string tiskanjeKodStr = null;
            string nacinTiskanjaImenStr = null;

            foreach (object obj in ((StackPanel)tiskanjeKod.Content).Children)
            {
                if (true == ((RadioButton)obj).IsChecked)
                {
                    tiskanjeKodStr = ((RadioButton)obj).Name;
                    break;
                }
            }
            
            if (_1xA4.IsChecked==true)
            {
                nacinTiskanjaImenStr = "_1xA4";
            }
            else if (_3x2xA4.IsChecked==true)
            {
                nacinTiskanjaImenStr = "_3x2xA4";
            }
            else if (_2x2xA4.IsChecked == true)
            {
                nacinTiskanjaImenStr = "_2x2xA4";
            } 
            else //_2xA4
            {
                nacinTiskanjaImenStr = "_2xA4";
            }
            

            bool tiskanjeKodBool = true;
            if (tiskanjeKodStr.Equals("_NE"))
            {
                tiskanjeKodBool = false;
            }

            
            
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.DefaultExt = "pdf";
            fDialog.Filter = "PDF dokumenti (.pdf)|*.pdf";
            if (fDialog.ShowDialog() == true)
            {
                PDFHandler.printBars(((App)App.Current).crossManager.CompetitorLst, fDialog.FileName, tiskanjeKodBool, nacinTiskanjaImenStr);
                try
                {
                    Process.Start(fDialog.FileName);
                } catch (Exception ex)
                {
                }
            }


        }

        private void izvoziTekmovalce_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.DefaultExt = "csv";
            fDialog.Filter = "CSV datoteke (.csv)|*.csv";
            if (fDialog.ShowDialog() == true)
            {

                char[] chTable = txtbx_csvSeparator.Text.ToCharArray();
                TextFileWriter.writeToFile(fDialog.FileName, chTable, ((App) App.Current).crossManager.CompetitorLst);
            }
        }

        private void uvoziTekmovalce_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.DefaultExt = "csv";
            fDialog.Filter = "CSV datoteke (.csv)|*.csv|Tekstovne datoteke (.txt)|*.txt";
            if (fDialog.ShowDialog() == true)
            {

                char[] chTable = txtbx_csvSeparator.Text.ToCharArray();
                List<Competitor> newList = TextFileReader.readFromFile(fDialog.FileName, chTable);
                ((App) App.Current).crossManager.addCompetitors(newList);
            }
            lst_tekmovalci.Items.Refresh();

            equalyEditIndexes();
        }

        private void equalyEditIndexes()
        {
            int numOfSkupin = Convert.ToInt32(nud_stSkupin.Value);
            int numOfTekmovalcev = lst_tekmovalci.Items.Count;
            if (numOfTekmovalcev != 0)
            {
                if (numOfSkupin >= numOfTekmovalcev)
                {
                    numOfSkupin = numOfTekmovalcev;
                    nud_stSkupin.Value = numOfSkupin;
                }
                int numTekmovalcevVSkupini = numOfTekmovalcev/numOfSkupin;

                int curSkupina = 1;
                for (int i = 0; i < ((App) App.Current).crossManager.CompetitorLst.Count; i++)
                {
                    ((App) App.Current).crossManager.CompetitorLst[i].Start_group = curSkupina;
                    if ((i + 1)%numTekmovalcevVSkupini == 0 && curSkupina < numOfSkupin)
                    {
                        curSkupina++;
                    }
                }
                lst_tekmovalci.Items.Refresh();
            }else
            {
                nud_stSkupin.Value = 1;
            }
        }

        private void listView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Competitor selectedCompetitor = (Competitor)lst_tekmovalci.SelectedItem;
                UrediTekmovalca urediTekmovalcaWindow = new UrediTekmovalca();
                int idx = ((App)App.Current).crossManager.CompetitorLst.IndexOf(selectedCompetitor);
                urediTekmovalcaWindow.preSet(((App)App.Current).crossManager.CompetitorLst[idx], idx);
                urediTekmovalcaWindow.ShowDialog();
                lst_tekmovalci.Items.Refresh();
            }
            catch (Exception e1)
            {
                Console.WriteLine("Ni bil izbran tekmovalec!");
            }
        }

        private void dodajTekmovalca_Click(object sender, RoutedEventArgs e)
        {
            UrediTekmovalca urediTekmovalcaWindow = new UrediTekmovalca();
            urediTekmovalcaWindow.ShowDialog();
            lst_tekmovalci.Items.Refresh();
            equalyEditIndexes();
        }

        private void nazaj_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ali res želite nazaj? " + System.Environment.NewLine + "*vse neshranjene spremembe bodo izgubljene", "Nazaj", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.None);
            if (result.ToString().Equals("Yes"))
            {
                ((App)App.Current).crossManager = null;
                Start start = new Start();
                start.Show();
                this.Close();
            }
        }

        private bool shraniTekmo()
        {
            bool result = false;
                SaveFileDialog fDialog = new SaveFileDialog();
                fDialog.DefaultExt = "cross";
                fDialog.Filter = "CrossManager datoteke (.cross)|*.cross";
                fDialog.FileName = txtbx_tekmaName.Text;
                if (fDialog.ShowDialog() == true)
                {
                    result = XMLHandler.shraniTekmo(fDialog.FileName, ((App) App.Current).crossManager,
                                                    txtbx_tekmaName.Text,
                                                    Convert.ToInt32(nud_stSkupin.Value));
                    this.tekmaFilename = fDialog.FileName;
                } else
                {
                    result = false;
                }
            return result;

        }

        private void shraniTekmo_Click(object sender, RoutedEventArgs e)
        {
            shraniTekmo();
        }

        private void zacniTekmo_Click(object sender, RoutedEventArgs e)
        {
            ((App) App.Current).crossManager.ImeTekme = txtbx_tekmaName.Text;
            ((App) App.Current).crossManager.StSkupin = Convert.ToInt32(nud_stSkupin.Value);

            if (tekmaFilename.Equals(""))
            {
                if (shraniTekmo())
                {
                    Tekma tekma = new Tekma(1, tekmaFilename);
                    tekma.Show();
                    this.Close();
                }
            }
            else
            {
                if (XMLHandler.shraniTekmo(tekmaFilename, ((App)App.Current).crossManager, txtbx_tekmaName.Text,
                                       Convert.ToInt32(nud_stSkupin.Value)))
                {
                    Tekma tekma = new Tekma(1, tekmaFilename);
                    tekma.Show();
                    this.Close();
                }
            }


            
        }

        private void stSkupin_Changed(object sender, EventArgs e)
        {
            equalyEditIndexes();
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
                        ((App) App.Current).crossManager.CompetitorLst.Remove(competitor);
                        lst_tekmovalci.Items.Refresh();
                    }
                }
            }catch (Exception ex)
            {
            }
        }
    }
}
