﻿#pragma checksum "..\..\PoTekmi.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "24ABB441F722F32527BD839F361D601A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CrossManager_WPF_GUI {
    
    
    /// <summary>
    /// PoTekmi
    /// </summary>
    public partial class PoTekmi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\PoTekmi.xaml"
        internal System.Windows.Controls.ListView lst_tekmovalci;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CrossManager_WPF_GUI;component/potekmi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PoTekmi.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lst_tekmovalci = ((System.Windows.Controls.ListView)(target));
            
            #line 13 "..\..\PoTekmi.xaml"
            this.lst_tekmovalci.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listView_DoubleClick);
            
            #line default
            #line hidden
            
            #line 13 "..\..\PoTekmi.xaml"
            this.lst_tekmovalci.KeyUp += new System.Windows.Input.KeyEventHandler(this.lstView_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 37 "..\..\PoTekmi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_shrani_spremembe_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 38 "..\..\PoTekmi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_tiskajRezultate);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 39 "..\..\PoTekmi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_izhod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
