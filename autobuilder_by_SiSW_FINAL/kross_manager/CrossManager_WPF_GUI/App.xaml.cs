using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using CrossManager_WPF_GUI.Properties;
using CrossManagerLibrary;

namespace CrossManager_WPF_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CrossManager crossManager = null;

        protected override void  OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
 	        base.OnExit(e);
        }

        [System.STAThreadAttribute()]
        static void Main()
        {
            App app = new App();
            try
            {
                
                app.InitializeComponent();
                app.Run();    
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }

        public static string addToTitle()
        {
            return " - " + getOrgName();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string[] arguments = e.Args;
            if (arguments.Length!=0)
            {
                StartArgs startArgs = new StartArgs(arguments[0]);
                startArgs.Show();
                this.MainWindow = startArgs;
            } else
            {
                this.StartupUri = new Uri("Start.xaml", UriKind.Relative);
            }
        }

        public static string getOrgName()
        {
            return "krena sola XXX" 
; 
        }



    }
}
