﻿#pragma checksum "C:\Users\macie\Downloads\przepisy i powiadomienia\przepisy i powiadomienia\Views\Przepisy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1F822D7A6ABDD1D7C167B9A6B81AB3DE"
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
    partial class Przepisy : 
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
                    global::Windows.UI.Xaml.Controls.AppBarButton element1 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 51 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element1).Click += this.Cofnij;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 52 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element2).Click += this.AppBarButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element3 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 53 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element3).Click += this.Button_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.Nazwy_przepisow = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 26 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.Nazwy_przepisow).SelectionChanged += this.Nazwy_przepisow_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.n0 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 35 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.n0).Checked += this.Wszy_Checked;
                    #line default
                }
                break;
            case 6:
                {
                    this.n1 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 36 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.n1).Checked += this.Sniad_Checked;
                    #line default
                }
                break;
            case 7:
                {
                    this.n2 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 37 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.n2).Checked += this.Obiad_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    this.n3 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 38 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.n3).Checked += this.Kolac_Checked;
                    #line default
                }
                break;
            case 9:
                {
                    this.cb1 = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    #line 39 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cb1).Checked += this.ggg;
                    #line 39 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cb1).Unchecked += this.ggg;
                    #line default
                }
                break;
            case 10:
                {
                    this.szukajka = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 41 "..\..\..\Views\Przepisy.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.szukajka).KeyUp += this.szukaj;
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

