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
using System.Data;
using Windows.UI;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class dodawanie_przepisu : Page
    {
        public int ilosc_klikniec = 0;
        public dodawanie_przepisu()
        {
            this.InitializeComponent();
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ilosc_klikniec++;
            createCB();
            

        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(Przepisy), null);
        }

        private void createCB()
        {
            
            if (ilosc_klikniec == 1)
            {
                TextBlock tblock = new TextBlock();
                tblock.FontSize = 20;
                tblock.Margin = new Thickness(250, 0, 0, 0);
                tblock.Text = "Składniki";


                TextBlock tblock2 = new TextBlock();
                tblock2.FontSize = 20;
                tblock2.Margin = new Thickness(360, 0, 0, 0);
                tblock2.Text = "Ilość (gramy)";

                combo.Children.Add(tblock);
                tekst.Children.Add(tblock2);

            }
            ComboBox cbox = new ComboBox();
            cbox.Width = 120;
            cbox.Height = 30;
            cbox.Name = "Combobox" + ilosc_klikniec;
            cbox.Margin = new Thickness(250, 10, 0, 0);

            TextBox tbox = new TextBox();
            tbox.Width = 50;
            tbox.Height = 30;
            tbox.Name = "Textbox" + ilosc_klikniec;
            tbox.Margin = new Thickness(360, 10, 0, 0);




            combo.Children.Add(cbox);
            tekst.Children.Add(tbox);

        }
    }
}
