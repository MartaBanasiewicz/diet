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
using Microsoft.Data.Sqlite;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Przepisy : Page
    {
        public Przepisy()
        {
            this.InitializeComponent();        
        }
        

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Dalej(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(przepis_calosc), null);
        }

        private void Wszy_Checked(object sender, RoutedEventArgs e)
        {
            fun();
        }
        
        private void Sniad_Checked(object sender, RoutedEventArgs e)
        {
            fun();
        }

        private void Obiad_Checked(object sender, RoutedEventArgs e)
        {
            fun();
        }

        private void Kolac_Checked(object sender, RoutedEventArgs e)
        {
            fun();
        }

        private void fun()
        {
            string typ = "0";
            if (n1 != null && n1.IsChecked == true)
            {
                typ = "1";
            }
            else if (n2 != null && n2.IsChecked == true)
            {
                typ = "2";
            }
            else if (n3 != null && n3.IsChecked == true)
            {
                typ = "3";
            }

            bool? isChecked = cb1 == null ? false : cb1.IsChecked;

            string szukane = szukajka != null ? szukajka.Text : "";

            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string polecenie = "SELECT Id, Nazwa FROM Przepisy";
                if (Convert.ToInt32(typ) > 0 || isChecked == true || szukane != "")
                {
                    polecenie += " WHERE ";
                    List<string> s = new List<string>();
                    if (Convert.ToInt32(typ) > 0)
                    {
                        s.Add("typ_potrawy=" + typ);
                    }
                    if (isChecked == true)
                    {
                        s.Add("ulubione=1");
                    }
                    if (szukane != "")
                    {
                        s.Add("Nazwa like \"%" + szukane.Replace('"', '_') +"%\"");
                    }
                    polecenie += String.Join(" AND ", s.ToArray());
                }

                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                Nazwy_przepisow.Items.Clear();
                while (wykon.Read())
                {
                    Nazwy_przepisow.Items.Add(new Przepis(Convert.ToInt32(wykon["Id"]), wykon["Nazwa"].ToString()));

                    Nazwy_przepisow.DisplayMemberPath = "Nazwa";
                    Nazwy_przepisow.SelectedValuePath = "Id";
                }
            }
        }

        public void szukaj(object sender, RoutedEventArgs e)
        {
            fun();
        }

        public void ggg(object sender, RoutedEventArgs e)
        {
            
            fun();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Przepisy), null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(dodawanie_przepisu), null);
        }

        private void Nazwy_przepisow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (sender as ListBox);
            //Zmienne.Id = Convert.ToInt32(lb.SelectedValue.ToString());
            //= lbi.();
            Frame.Navigate(typeof(przepis_calosc), Convert.ToInt32(lb.SelectedValue.ToString()));
        }
    }
}
