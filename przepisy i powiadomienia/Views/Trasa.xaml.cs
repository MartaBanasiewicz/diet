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
using Windows.Devices.Geolocation;
using Microsoft.Data.Sqlite;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Services.Maps;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Trasa : Page
    {
        public Trasa()
        {
            this.InitializeComponent();
            PunktStartowy();
            SzukajTrasy();
        }
        private void powMape(object sender, RoutedEventArgs e)
        {
            Mapa.ZoomLevel++;
        }

        private void pomMape(object sender, RoutedEventArgs e)
        {
            Mapa.ZoomLevel--;
        }
       private async void PunktStartowy()
        {
            Geolocator mojGPS = new Geolocator { DesiredAccuracy = PositionAccuracy.High };
            Geoposition mojeZGPS = await mojGPS.GetGeopositionAsync();
            DaneGeograficzne.pktStartowy = mojeZGPS.Coordinate.Point.Position;
            Geopoint centruj = new Geopoint(DaneGeograficzne.pktStartowy);
            await Mapa.TrySetViewAsync(centruj, 16);
            MapIcon pktStartowy = new MapIcon { Location = centruj, Title = "Tu jestes" };
            Mapa.MapElements.Add(pktStartowy);

        }
       private async void SzukajTrasy()
        {
            if (DaneGeograficzne.pktKoncowy.Longitude != 0 && DaneGeograficzne.pktKoncowy.Latitude != 0)
            {
                Mapa.MapElements.Clear();
                Geopoint centruj = new Geopoint(DaneGeograficzne.pktStartowy);
                MapIcon pktStartowy = new MapIcon { Location = centruj, Title = "Początek Trasy" };
                Mapa.MapElements.Add(pktStartowy);
                Geopoint punktT = new Geopoint(DaneGeograficzne.pktKoncowy);
                MapIcon punkt = new MapIcon { Location = punktT, Title = "Koniec trasy" };
                Mapa.MapElements.Add(punkt);
                MapRouteFinderResult routeResult = await MapRouteFinder.GetWalkingRouteAsync(
                  new Geopoint(DaneGeograficzne.pktStartowy),
                  new Geopoint(DaneGeograficzne.pktKoncowy));
                if (routeResult.Status == MapRouteFinderStatus.Success)
                {
                    Mapa.Routes.Clear();

                    MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                    viewOfRoute.RouteColor = Windows.UI.Colors.Yellow;
                    viewOfRoute.OutlineColor = Colors.Black;
                    Mapa.Routes.Add(viewOfRoute);
                    await Mapa.TrySetViewBoundsAsync(
                routeResult.Route.BoundingBox,
                null,
                Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
                    double dlugoscTras = routeResult.Route.LengthInMeters / 1000;
                    DlugoscT.Text = "Długośc trasy:  " + dlugoscTras.ToString() + " km";
                    SzCzas.Text = "Szacowany Czas przejścia trasy: " + routeResult.Route.EstimatedDuration.ToString();
                    double spKalorie = routeResult.Route.EstimatedDuration.TotalMinutes * 2.8;
                    tbKalorie.Text = "Szacowana ilość spalonych kalorii: " + spKalorie.ToString();
                    tbNtrasy.Width = 200;
                    nTrasy.Text = "Nazwa trasy: ";
                    tbNtrasy.Text = DaneGeograficzne.nazwaTrasy;
                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Nie udało się zanaleść trasy");
                }
            }


        }
        private void DodajPunkt(MapControl sender, MapInputEventArgs args)
        {

            Mapa.MapElements.Clear();
            Geopoint centruj = new Geopoint(DaneGeograficzne.pktStartowy);
            MapIcon pktStartowy = new MapIcon { Location = centruj, Title = "Tu jestes" };
            Mapa.MapElements.Add(pktStartowy);
            DaneGeograficzne.pktKoncowy = args.Location.Position;
            Geopoint punktT = new Geopoint(DaneGeograficzne.pktKoncowy);
            MapIcon punkt = new MapIcon { Location = punktT, Title = "Koniec trasy" };
            Mapa.MapElements.Add(punkt);
            DaneGeograficzne.nazwaTrasy = "Trasa01";
            SzukajTrasy();
        }

        private async void dodajDoUlubionych(object sender, RoutedEventArgs e)
        {
            if (DaneGeograficzne.pktKoncowy.Latitude == 0 || DaneGeograficzne.pktKoncowy.Longitude == 0)
            {
                Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog("Wybierz swój cel na mapie");
                await dialog.ShowAsync();
            }

            else if (tbNtrasy.Text == String.Empty)
            {
                Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog("Musisz podać nazwę trasy");
                await dialog.ShowAsync();
            }
            else
            {
                double pktStart_szer = DaneGeograficzne.pktStartowy.Latitude;
                double pktStart_dlg = DaneGeograficzne.pktStartowy.Longitude;
                double pktKoniec_szer = DaneGeograficzne.pktKoncowy.Latitude;
                double pktKoniec_dlg = DaneGeograficzne.pktKoncowy.Longitude;
                using (SqliteConnection db = new SqliteConnection("FileName = ppp.db"))
                {
                    db.Open();
                    string polecenie2 = "SELECT nazwa from adresy;";
                    bool spr = false;
                    SqliteCommand command2 = new SqliteCommand(polecenie2, db);
                    SqliteDataReader wykon2 = command2.ExecuteReader();
                    while (wykon2.Read())
                    {
                        string str = wykon2.GetString(0);
                        if (tbNtrasy.Text == str)
                        {
                            spr = true;
                        }
                    }
                    if (spr == true)
                    {
                        db.Close();
                        var dialog = new Windows.UI.Popups.MessageDialog("Nazwa trasy nie może sie powtarzać");
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        string polecenie = "INSERT INTO Adresy (Nazwa, adres_start_dlg, adres_start_szer, adres_koniec_dlg, adres_koniec_szer) values ('" + tbNtrasy.Text + "','" + pktStart_dlg + "','" + pktStart_szer + "','" + pktKoniec_dlg + "','" + pktKoniec_szer + "');";
                        SqliteCommand command = new SqliteCommand(polecenie, db);
                        command.ExecuteReader();
                        db.Close();
                        var dialog = new Windows.UI.Popups.MessageDialog("Dodano nową trasę do ulubionych");
                        await dialog.ShowAsync();
                    }
                }
            }
        }
        private void Ulubione(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UlubioneT));
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}


