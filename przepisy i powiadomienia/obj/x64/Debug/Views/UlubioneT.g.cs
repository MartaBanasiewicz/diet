﻿#pragma checksum "C:\Users\macie\Downloads\przepisy i powiadomienia\przepisy i powiadomienia\Views\UlubioneT.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BA7560A38F08763FB8F3B34BED510737"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace przepisy_i_powiadomienia.Views
{
    partial class UlubioneT : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.bWstecz = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 25 "..\..\..\Views\UlubioneT.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.bWstecz).Click += this.Cofnij;
                    #line default
                }
                break;
            case 2:
                {
                    this.bSzukaj = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 26 "..\..\..\Views\UlubioneT.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.bSzukaj).Click += this.Szukaj;
                    #line default
                }
                break;
            case 3:
                {
                    this.uTrase = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 27 "..\..\..\Views\UlubioneT.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.uTrase).Click += this.Usun;
                    #line default
                }
                break;
            case 4:
                {
                    this.lbTrasy = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 5:
                {
                    this.tbTrasy = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

