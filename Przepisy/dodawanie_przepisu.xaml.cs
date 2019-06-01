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
using Microsoft.Data.Sqlite;
using Windows.UI.Popups;
using SQLitePCL;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class dodawanie_przepisu : Page
    {
        public int ilosc_klikniec = 0;

        private List<Skladnik> skladniki = new List<Skladnik>();
        // private List<Skladnik> usuniete = new List<Skladnik>();
        private List<SkladnikiPrzepisy> skladnikiprzepisy = new List<SkladnikiPrzepisy>();

        public dodawanie_przepisu()
        {
            this.InitializeComponent();
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string polecenie = "SELECT `Id`, `Nazwa`, `Kalorie` FROM Skladniki";
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                while (wykon.Read())
                {
                    
                    //string sk = wykon.GetString(0);
                    skladniki.Add(new Skladnik(
                        Convert.ToInt32(wykon["Id"].ToString()),
                        wykon["Nazwa"].ToString(),
                        Convert.ToInt32(wykon["Kalorie"].ToString())
                    ));
                }
                laczenie.Close();
            }
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createCB();
            ilosc_klikniec++;
        }

        private async void funkcja(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox);
            Grid p = c.Parent as Grid;
            TextBox t = p.Children[1] as TextBox;
            int tt = Convert.ToInt32(t.Text.ToString());
            int yy = Convert.ToInt32(c.SelectedValue);
            if (!skladnikiprzepisy.Any(b => b.SkladnikId == yy))
            {
                int kal = (skladniki.Where(s => s.Id == yy).SingleOrDefault()).Kalorie;
                zmien(
                    yy,
                    tt,
                    kal
                );
                double dd = (double)kal * tt / 100;
                (p.Children[3] as TextBlock).Text = dd.ToString("F2");
                kalorie();
            } else
            {
                Windows.UI.Popups.MessageDialog dlg = new Windows.UI.Popups.MessageDialog("Ten składnik jest już na liście", "Wprowadź ponownie");
                dlg.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                await dlg.ShowAsync();
            }
        }
        private void CommandInvokedHandler(IUICommand command)
        {
            // Display message showing the label of the command that was invoked
            //rootPage.NotifyUser("The '" + command.Label + "' command has been selected.",
            //    NotifyType.StatusMessage);
        }

        private void kalorie()
        {
            List<SkladnikiPrzepisy> ko = skladnikiprzepisy.Where(o => o.Ilosc > 0).ToList<SkladnikiPrzepisy>();
            if (ko.Count > 0) {
                double kalorie = ko.Sum(w => (double)w.Kalorie * w.Ilosc / 100);
                kcal.Text = kalorie.ToString("F2");
            }
        }

        private void createCB()
        {
            ComboBox cbox = new ComboBox();
            cbox.SelectionChanged += new SelectionChangedEventHandler(funkcja);
            cbox.Width = 220;
            cbox.Height = 30;
            cbox.ItemsSource = skladniki;
            cbox.DisplayMemberPath = "Nazwa";
            cbox.SelectedValuePath = "Id";

            TextBox tbox = new TextBox();
            tbox.Width = 50;
            tbox.Height = 30;
            tbox.Text = "0";
            tbox.KeyUp += new KeyEventHandler(funkcja1);

            Button del = new Button();
            del.Content = "x";
            del.Click += new RoutedEventHandler(usuwanie);

            TextBlock tbb = new TextBlock();
            tbb.Width = 50;
            tbb.Height = 30;
            tbb.Text = "0";

            /* if (ilosc_klikniec == 1)
             {
                 TextBlock tblock = new TextBlock();
                 tblock.Width = 50;
                 tblock.Height = 30;
                 tblock.Text = "Nazwa składnika";
                 tblock.FontSize = 20;

                 TextBlock tblock2 = new TextBlock();
                 tblock2.Width = 50;
                 tblock2.Height = 30;
                 tblock2.Text = "Ilość (gram)";
                 tblock2.FontSize = 20;


             }*/

            Grid g = new Grid();
            g.Margin = new Thickness(10, 10, 10, 10);
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            g.HorizontalAlignment = HorizontalAlignment.Center;
            
            Grid.SetColumn(cbox, 0);
            Grid.SetColumn(tbox, 1);
            Grid.SetColumn(del, 2);
            Grid.SetColumn(tbb, 3);


            g.Children.Add(cbox);
            g.Children.Add(tbox);
            g.Children.Add(del);
            g.Children.Add(tbb);
            dodawanko.Children.Add(g);
        }

        private void funkcja1(object sender, KeyRoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            Grid p = t.Parent as Grid;
            //string cb = t.Name.Split('_')[0].ToString();
            ComboBox c = p.Children[0] as ComboBox;
            if (c.SelectedIndex > -1)
            {
                int s = Convert.ToInt32(c.SelectedValue.ToString());
                int y = 0;
                int kal = (skladniki.Where(w => w.Id == s).SingleOrDefault()).Kalorie;
                int.TryParse(t.Text.ToString(), out y);
                zmien(
                    s,
                    y,
                    kal
                );
                double dd = (double)kal * y / 100;
                (p.Children[3] as TextBlock).Text = dd.ToString("F2");
                kalorie();
            } 
        }

        private void zmien(int SkladnikId, int Ilosc, int Kalorie)
        {
            bool exist = skladnikiprzepisy.Any(o => o.SkladnikId == SkladnikId);
            if (exist)
            {
                skladnikiprzepisy.Remove(skladnikiprzepisy.Where(o => o.SkladnikId == SkladnikId).SingleOrDefault());
            }
            skladnikiprzepisy.Add(new SkladnikiPrzepisy() { PrzepisId = 0, SkladnikId = SkladnikId, Ilosc = Ilosc, Kalorie = Kalorie });
            kalorie();
        }

        private void usuwanie(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            Grid p = (b.Parent as Grid);
            if ((p.Children[0] as ComboBox).SelectedIndex > -1)
            {
                string sv = (p.Children[0] as ComboBox).SelectedValue.ToString();

                SkladnikiPrzepisy XD = skladnikiprzepisy.Where(o => o.SkladnikId.ToString() == sv).SingleOrDefault();
                skladnikiprzepisy.Remove(XD);
            }
            dodawanko.Children.Remove(p);
            kalorie();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            int typ_pot = 0;
            string nazwa = NazwaP.Text;
            string przepis = Przepis.Text.ToString();

            if (rb1.IsChecked == true) { typ_pot = 1; }
            else if (rb2.IsChecked == true) { typ_pot = 2; }
            else if (rb3.IsChecked == true) { typ_pot = 3; }

            double xyx = 0.0;
            double.TryParse(kcal.Text, out xyx);

            // insert przepis get last inserted id
            string insert = "insert into Przepisy (Nazwa, typ_potrawy, kcal, moj_przepis, przepis) values " +
                "(\"" + nazwa + "\","+ typ_pot + "," + Math.Round(xyx, 0, MidpointRounding.ToEven) + ", 1,\""+ przepis + "\")";

            // using
            SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db");
            int przepis_id = 0;
            using (SqliteCommand polecenieSQL1 = new SqliteCommand(insert, laczenie))
            {
                laczenie.Open();
                SqliteTransaction transaction = laczenie.BeginTransaction();
                polecenieSQL1.Transaction = transaction;
                polecenieSQL1.ExecuteNonQuery();

                SqliteCommand sql = new SqliteCommand(@"select last_insert_rowid()", laczenie);
                sql.Transaction = transaction;
                przepis_id = Convert.ToInt32(sql.ExecuteScalar());


                transaction.Commit();
                laczenie.Close();
            }


            

            /*using (SqliteCommand polecenieSQL2 = new SqliteCommand(xx, laczenie))
            {
                laczenie.Open();
                var cc = polecenieSQL2.ExecuteScalar();
                przepis_id = Convert.ToInt32(cc);
                laczenie.Close();
            }*/

            if (przepis_id > 0)
            {
                insert = "insert into SkladnikiPrzepisy (PrzepisId, SkladnikId, Ilosc) VALUES ";

                foreach (SkladnikiPrzepisy sp in skladnikiprzepisy)
                {
                    sp.PrzepisId = przepis_id;
                    insert += "(" + sp.PrzepisId + "," + sp.SkladnikId + "," + sp.Ilosc + "),";
                }
                insert = insert.TrimEnd(new char[] { ',' });

                insert += ";";

                using (SqliteCommand polecenieSQL3 = new SqliteCommand(insert, laczenie))
                {
                    laczenie.Open();
                    polecenieSQL3.ExecuteNonQuery();
                    laczenie.Close();
                }
            }
            else
            {
                // blad 
            }
             laczenie.Close();

            Frame.Navigate(typeof(Przepisy), null);
        }
    }
}
