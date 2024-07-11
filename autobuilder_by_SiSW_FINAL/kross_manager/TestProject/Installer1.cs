using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace TestProject
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            // shrani bla na tra



        }
    }
}
