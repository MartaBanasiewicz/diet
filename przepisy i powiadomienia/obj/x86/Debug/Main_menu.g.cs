﻿#pragma checksum "C:\Users\User\source\repos\przepisy i powiadomienia\przepisy i powiadomienia\Main_menu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2DA4F091D78FAB705BED34AB15E43558"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace przepisy_i_powiadomienia
{
    partial class Main_menu : 
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
                    global::Windows.UI.Xaml.Controls.Image element1 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 34 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element1).Tapped += this.Wskazniki;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Image element2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 37 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element2).Tapped += this.Powiadomienia;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Image element3 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 40 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element3).Tapped += this.Cele;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Image element4 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 23 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element4).Tapped += this.Przepisy;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Image element5 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 26 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element5).Tapped += this.Trasa;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Image element6 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 29 "..\..\..\Main_menu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element6).Tapped += this.Statystyki;
                    #line default
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
