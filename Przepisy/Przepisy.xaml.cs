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
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
               
                laczenie.Open();
                //comboboxy do filtrowania
                string polecenie1 = "SELECT * FROM Skladniki";
                SqliteCommand polecenieSQL2 = new SqliteCommand(polecenie1, laczenie);
                SqliteDataReader wykon2 = polecenieSQL2.ExecuteReader();
                while (wykon2.Read())
                {
                    string name = wykon2.GetString(1);
                    Combobox1.Items.Add(name);
                    Combobox2.Items.Add(name);
                    Combobox3.Items.Add(name);                  
                }
                laczenie.Close();
            }
            Select();
        }
        
        private void funkcja_radiocheckbox()
        {

        }
        private void funkcja_combo()
        {

        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Dalej(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(przepis_calosc), null);
        }

        private void Select()
        {
            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                laczenie.Open();
                string polecenie = "SELECT * FROM Przepisy";
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                while (wykon.Read())
                {
                    string name = wykon.GetString(1);
                    Nazwy_przepisow.Items.Add(name);

                }
            }
        }

        private void Szukaj(object sender, RoutedEventArgs e)
        {

        }

        private void Usun(object sender, RoutedEventArgs e)
        {

        }

        private void Wszy_Checked(object sender, RoutedEventArgs e)
        {
            zrobcos(sender);
        }

        
        private void Sniad_Checked(object sender, RoutedEventArgs e)
        {
            zrobcos(sender);
        }

        private void Obiad_Checked(object sender, RoutedEventArgs e)
        {
            zrobcos(sender);
        }

        private void Kolac_Checked(object sender, RoutedEventArgs e)
        {
            zrobcos(sender);
        }

        private void zrobcos(object sender)
        {
            Nazwy_przepisow.Items.Clear();
            RadioButton rb = (sender as RadioButton);
            

            using (SqliteConnection laczenie = new SqliteConnection("FileName = ppp.db"))
            {
                
                //listbox
                laczenie.Open();
                string polecenie = "SELECT Id, Nazwa FROM Przepisy";
                if (rb.Name.TrimStart('n').ToString() != "0")
                {
                    polecenie += " WHERE typ_potrawy=" + Convert.ToUInt32(rb.Name.TrimStart('n').ToString());
                }
                
                SqliteCommand polecenieSQL = new SqliteCommand(polecenie, laczenie);
                SqliteDataReader wykon = polecenieSQL.ExecuteReader();
                while (wykon.Read())
                {
                    //string name = wykon["Nazwa"].ToString();
                    //string id = wykon["Id"].ToString();
                    Nazwy_przepisow.Items.Add(wykon);
                    
                    Nazwy_przepisow.DisplayMemberPath = "Nazwa";
                    Nazwy_przepisow.SelectedValuePath = "Id";
                }
            }

        }

    }
}
