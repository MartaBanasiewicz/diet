﻿#pragma checksum "C:\Users\macie\Desktop\przepisy i powiadomienia\przepisy i powiadomienia\dodawanie_przepisu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9786AFCB74AA901D67DB0C64A3690D10"
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
    partial class dodawanie_przepisu : 
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
                    #line 68 "..\..\..\dodawanie_przepisu.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element1).Click += this.Cofnij;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element2 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 69 "..\..\..\dodawanie_przepisu.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element2).Click += this.Dodaj;
                    #line default
                }
                break;
            case 3:
                {
                    this.NazwaP = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.Przepis = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.rb1 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 6:
                {
                    this.rb2 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 7:
                {
                    this.rb3 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 8:
                {
                    this.kcal = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\dodawanie_przepisu.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.dodawanko = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 11:
                {
                    this.lbox_przepis = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

