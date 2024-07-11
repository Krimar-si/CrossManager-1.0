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
using InputLibrary;

namespace CrossManagerGUI
{
    /// <summary>
    /// Interaction logic for PripravaTekme.xaml
    /// </summary>
    public partial class PripravaTekme : Window
    {
        public PripravaTekme()
        {
            InitializeComponent();

            

            lst_tekmovalci.ItemsSource = list;

            
        }
    }
}
