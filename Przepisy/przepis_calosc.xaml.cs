using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class przepis_calosc : Page
    {
        public int czy_ulubione = 0;
        string v;

        
        public przepis_calosc()
        {
            this.InitializeComponent();
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string polecenie = "select * from przepisy where Id = \"" + v + "\"";
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                while (wykon.Read())
                {
                    string name = wykon.GetString(1);
                    Skladniki.Items.Add(name);

                }
            }
        }
        
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(dodawanie_przepisu), null);
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Ulubione(object sender, RoutedEventArgs e)
        {
            if (czy_ulubione == 0)
            {
                Ulubione1.Icon.Foreground = new SolidColorBrush(Colors.Yellow);
                
                czy_ulubione = 1; 

            }
            else
            {
                Ulubione1.Icon.Foreground = new SolidColorBrush(Colors.Black);

                czy_ulubione = 0;
            }
        }

        
    }
}
