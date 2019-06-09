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
        int przepis = 0;

        Przepis prze;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            przepis = Convert.ToInt32(e.Parameter);
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string p = "select Id, Nazwa, ulubione, przepis, kcal from Przepisy where Id = " + przepis;
                SqliteCommand polecenieSQLw = new SqliteCommand(p, laczenie);
                SqliteDataReader wykonw = polecenieSQLw.ExecuteReader();

                while (wykonw.Read())
                {
                    Przepis.Text = wykonw["przepis"].ToString();
                    prze = new Przepis(Convert.ToInt32(wykonw["Id"].ToString()), wykonw["Nazwa"].ToString(), Convert.ToInt32(wykonw["ulubione"].ToString()), Convert.ToInt32(wykonw["kcal"].ToString()));
                }
                nazwaP.Text = prze.Nazwa + " (" + prze.Kalorie + " kcal)";
                if (prze.Ulubiony == 1)
                {
                    Ulubione1.Icon.Foreground = new SolidColorBrush(Colors.Yellow);
                }

                string polecenie = "select s.Nazwa, sp.Ilosc from Skladniki s" +
                    " inner join SkladnikiPrzepisy sp on sp.SkladnikId = s.Id" +
                    " where sp.PrzepisId = \"" + przepis + "\"";
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                while (wykon.Read())
                {
                    string name = wykon.GetString(0);
                    int ilosc = Convert.ToInt32(wykon.GetString(1));
                    //Skladniki.Items.Add(name);
                    TextBlock tb = new TextBlock();
                    tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tb.TextAlignment = TextAlignment.Left;
                    tb.Text = name;
                    tb.FontSize = 30;
                    tb.Height = 40;
                    tb.TextWrapping = TextWrapping.WrapWholeWords;

                    TextBlock tb2 = new TextBlock();
                    tb2.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tb2.TextAlignment = TextAlignment.Right;
                    tb2.Text = ilosc.ToString() + "g";
                    
                    tb2.FontSize = 30;
                    tb2.Height = 40;

                    Grid g = new Grid();
                    g.ColumnDefinitions.Add(new ColumnDefinition());
                    g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
                    g.HorizontalAlignment = HorizontalAlignment.Stretch;

                    Grid.SetColumn(tb, 0);
                    Grid.SetColumn(tb2, 1);

                    g.Children.Add(tb);
                    g.Children.Add(tb2);

                    Skladniki.Children.Add(g);
                }
                if (Skladniki.Children.Count == 0)
                {
                    polecenie = "select skladniki from Przepisy where Id = " + przepis;
                    SqliteCommand polecenieSQLq = new SqliteCommand(polecenie, laczenie);
                    SqliteDataReader wykonq = polecenieSQLq.ExecuteReader();
                    while (wykonq.Read())
                    {
                        string name = wykonq.GetString(0);
                        List<string> xx = name.Split(',').ToList();
                        foreach (string o in xx)
                        {
                            TextBlock tb1 = new TextBlock();
                            tb1.HorizontalAlignment = HorizontalAlignment.Stretch;
                            tb1.Text = o.Trim(' ');
                            tb1.FontSize = 30;
                            tb1.Height = 40;
                            tb1.TextWrapping = TextWrapping.WrapWholeWords;
                            Skladniki.Children.Add(tb1);
                        }
                    }
                }
            }
        }
       
        public przepis_calosc()
        {
            this.InitializeComponent();
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Usun(object sender, RoutedEventArgs e)
        {

            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string polecenie = "Delete from Przepisy where Id = \"" + prze.Id + "\"";
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                //SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                polecenieSQL.ExecuteNonQuery();
                laczenie.Close();
                Frame.GoBack();
            }

        }

        private void Ulubione(object sender, RoutedEventArgs e)
        {
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string p = "update Przepisy set ulubione = ABS(ulubione - 1) where Id = " + przepis;
                SqliteCommand polecenieSQLw = new SqliteCommand(p, laczenie);
                polecenieSQLw.ExecuteNonQuery();

                prze.Ulubiony = Math.Abs(prze.Ulubiony - 1);
                if (prze.Ulubiony == 1)
                {
                    Ulubione1.Icon.Foreground = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    Ulubione1.Icon.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        
    }
}
