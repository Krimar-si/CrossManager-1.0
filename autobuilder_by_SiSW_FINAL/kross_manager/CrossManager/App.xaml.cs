using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using CrossManagerGUI.Properties;
using InputLibrary;

namespace CrossManagerGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        CrossManagerGUI crossManager = new CrossManager();

        protected override void  OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
 	        base.OnExit(e);
        }
 
    }
}
