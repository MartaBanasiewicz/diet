using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class Wskazniki : Page
    {
        public Wskazniki()
        {
            this.InitializeComponent();
        }

        private Plec sex = Plec.BrakInformacji;
        private double age = 0;
        private double weight = 0;
        private double height = 0;
        private double waist = 0;
        private double hip = 0;

        private void Kobieta_rb_Checked(object sender, RoutedEventArgs e)
        {
            sex = Plec.Kobieta;
        }

        private void Mezczyzna_rb_Checked(object sender, RoutedEventArgs e)
        {
            sex = Plec.Mezczyzna;
        }


        public void Wyniki_Click(object sender, RoutedEventArgs e)
        {
            CalculateBMI();
            CalcultateWHR();
            CalcultateBMR();
            CalculateAMR();         
        }

        public void Whr_tb_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Wskazniki), null);
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void CalculateBMI()
        {
            bmi_tb.Text = Math.Round((weight * 10000/ (height * height)), 2).ToString();
        }

        private void CalcultateWHR()
        {
            whr_tb.Text = Math.Round(waist / hip, 2).ToString();
        }

        private void CalcultateBMR()
        {
            double bmr = 9.99 * weight + 6.25 * height - 4.92 * age;

            switch (sex)
            {
                case Plec.Kobieta:
                    bmr -= 161;
                    break;
                case Plec.Mezczyzna:
                    bmr += 5;
                    break;
                default:
                    break;
            }

            bmr_tb.Text = Math.Round(bmr, 2).ToString();
        }

        private void CalculateAMR()
        {
            double amr = 9.99 * weight + 6.25 * height - 4.92 * age;

            switch (sex)
            {
                case Plec.Kobieta:
                    amr -= 161;
                    break;
                case Plec.Mezczyzna:
                    amr += 5;
                    break;
                default:
                    break;
            }

            amr_tb.Text = Math.Round(amr * 1.4, 2).ToString();
        }

       

        internal enum Plec
        {
            BrakInformacji,
            Kobieta,
            Mezczyzna
        }

        private void Wiek_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(wiek_tb.Text, out age);
        }

        private void Wzrost_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(wzrost_tb.Text, out height);
        }

        private void Masa_ciala_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(masa_ciala_tb.Text, out weight);
        }

        private void Obwod_pasa_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(obwod_pasa_tb.Text, out waist);
        }

        private void Obwod_bioder_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(obwod_bioder_tb.Text, out hip);
        }

        private void tbInput_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int itemp;
            if (!int.TryParse(sender.Text, out itemp) && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1 >= 0 ? sender.SelectionStart - 1 : 0;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }
    }
}
