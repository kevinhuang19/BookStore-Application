﻿#pragma checksum "..\..\AccountDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4520ECCEE0B85CE1180FF326A5068D6F65D578E015136A9ED7BFEA75AAF35A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookStoreGUI;
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


namespace BookStoreGUI {
    
    
    /// <summary>
    /// AccountDialog
    /// </summary>
    public partial class AccountDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fromDate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker toDate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orderDataGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn orderIDColumn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn orderDateColumn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn statusColumn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn totalColumn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PaypalMethodsGrid;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CardMethodsGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addPayment;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AccountDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removePayment;
        
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
            System.Uri resourceLocater = new System.Uri("/BookStoreGUI;component/accountdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AccountDialog.xaml"
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
            
            #line 9 "..\..\AccountDialog.xaml"
            ((BookStoreGUI.AccountDialog)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fromDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 14 "..\..\AccountDialog.xaml"
            this.fromDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.FromDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.toDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 16 "..\..\AccountDialog.xaml"
            this.toDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.ToDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AccountDialog.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AccountDialog.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.orderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\AccountDialog.xaml"
            this.orderDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OrderDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.orderIDColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.orderDateColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.statusColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.totalColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.PaypalMethodsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.CardMethodsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.addPayment = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\AccountDialog.xaml"
            this.addPayment.Click += new System.Windows.RoutedEventHandler(this.addPayment_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.removePayment = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\AccountDialog.xaml"
            this.removePayment.Click += new System.Windows.RoutedEventHandler(this.removePayment_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
