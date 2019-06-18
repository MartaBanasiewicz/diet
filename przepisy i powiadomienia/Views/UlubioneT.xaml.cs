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
using Windows.Storage;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class UlubioneT : Page
    {
        public UlubioneT()
        {
            this.InitializeComponent();
            wczytajBazeD();
        }

        void wczytajBazeD()
        {
            using (SqliteConnection db = new SqliteConnection("FileName = ppp.db"))
            {
                db.Open();
                string polecenie = "SELECT nazwa from adresy;";
                SqliteCommand command = new SqliteCommand(polecenie, db);
                SqliteDataReader wykon = command.ExecuteReader();
                while (wykon.Read())
                {
                    string sk = wykon.GetString(0);
                    lbTrasy.Items.Add(sk);
                }
                db.Close();
            }
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }


        private async void Szukaj(object sender, RoutedEventArgs e)
        {
            if (lbTrasy.SelectedItems.Count() == 0)
            {
                var dialog = new MessageDialog("Wybierz trasę z listy");
                await dialog.ShowAsync();
            }
            else
            {
                string nazwa = lbTrasy.SelectedItem.ToString();
                string ad_start_dlg = "";
                string ad_start_szer = "";
                string ad_koniec_dlg = "";
                string ad_koniec_szer = "";
                using (SqliteConnection db = new SqliteConnection("FileName = ppp.db"))
                {
                    db.Open();
                    string polecenie = "select adres_start_dlg, adres_start_szer,adres_koniec_dlg,adres_koniec_szer from Adresy where Nazwa='" + nazwa + "';";
                    SqliteCommand command = new SqliteCommand(polecenie, db);
                    SqliteDataReader wykon = command.ExecuteReader();
                    while (wykon.Read())
                    {
                        ad_start_dlg = wykon.GetString(0);
                        ad_start_szer = wykon.GetString(1);
                        ad_koniec_dlg = wykon.GetString(2);
                        ad_koniec_szer = wykon.GetString(3);
                    }
                    db.Close();
                }
                DaneGeograficzne.pktStartowy.Latitude = Convert.ToDouble(ad_start_szer);
                DaneGeograficzne.pktStartowy.Longitude = Convert.ToDouble(ad_start_dlg);
                DaneGeograficzne.pktKoncowy.Latitude = Convert.ToDouble(ad_koniec_szer);
                DaneGeograficzne.pktKoncowy.Longitude = Convert.ToDouble(ad_koniec_dlg);
                DaneGeograficzne.nazwaTrasy = nazwa;
                Frame.GoBack();
            }
        }

        private async void Usun(object sender, RoutedEventArgs e)
        {

            string nazwa;
            if (lbTrasy.SelectedItems.Count() == 0)
            {
                var dialog = new MessageDialog("Wybierz trasę z listy");
                await dialog.ShowAsync();
            }
            else
            {
                nazwa = lbTrasy.SelectedItem.ToString();
                using (SqliteConnection db = new SqliteConnection("FileName = ppp.db"))
                {
                    db.Open();
                    string polecenie = "DELETE FROM Adresy WHERE Nazwa ='" + nazwa + "';";
                    SqliteCommand command = new SqliteCommand(polecenie, db);
                    SqliteDataReader wykon = command.ExecuteReader();
                    db.Close();
                }
                lbTrasy.Items.Clear();
                wczytajBazeD();
            }
        }
    }
}
