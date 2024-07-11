using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrossManagerLibrary;

namespace CrossManagerGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Tekma : Window
    {
        CrossStopWatch stopWatch = new CrossStopWatch();
        private Thread t = null;


        public Tekma()
        {
            InitializeComponent();
            stopWatch.Start();
            stopWatchTxtBlck.DataContext = stopWatch;
            t = new Thread(new ThreadStart(this.makeStopWatchChangeEvent));
            t.Start();
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
            t.Abort();
        }


    }

}
