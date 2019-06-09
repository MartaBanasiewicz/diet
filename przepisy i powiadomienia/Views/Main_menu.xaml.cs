using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main_menu : Page
    {
        public Main_menu()
        {
            this.InitializeComponent();
        }



        private void Przepisy(object sender, TappedRoutedEventArgs e)
        {
             Frame.Navigate(typeof(Przepisy), null);
            //Frame.Navigate(typeof(dodawanie_przepisu), null);
        }

        private void Trasa(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Statystyki(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Statystyki));
        }

        private void Wskazniki(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Wskazniki));
        }

        private void Powiadomienia(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Cele(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Cele));

        }

        private void PointerEntered2(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PointerExited2(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
    }
}
