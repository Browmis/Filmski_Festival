﻿#pragma checksum "..\..\..\windows\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9EB69D588BFDED828509B7D67CC14E4C529C53A1CBB23D51C98C487DBDCF4D59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Festival.windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using System.Windows.Shell;


namespace Festival.windows {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxGenre;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxYear;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxDirector;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listFilms;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilm;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\windows\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Festival;component/windows/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\windows\Menu.xaml"
            ((Festival.windows.Menu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbxGenre = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\..\windows\Menu.xaml"
            this.cbxGenre.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxGenre_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbxYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\windows\Menu.xaml"
            this.cbxYear.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxYear_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbxDirector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\windows\Menu.xaml"
            this.cbxDirector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxDirector_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.listFilms = ((System.Windows.Controls.ListBox)(target));
            
            #line 16 "..\..\..\windows\Menu.xaml"
            this.listFilms.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.selection);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtFilm = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\windows\Menu.xaml"
            this.txtFilm.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFilm_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 18 "..\..\..\windows\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 19 "..\..\..\windows\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\windows\Menu.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

