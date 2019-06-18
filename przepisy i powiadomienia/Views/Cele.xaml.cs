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
    public sealed partial class Cele : Page
    {
        public Cele()
        {
            this.InitializeComponent();
            target = db.Targets.FirstOrDefault();
            measurement = db.Measurements.LastOrDefault();
            SetTargetTextBoxes();
            SetMeasurementTextBoxes();
        }

        PoradnikContext db = new PoradnikContext();
        Target target;
        Measurement measurement;

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Wskazniki), null);
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void SetTargetTextBoxes()
        {
            if (target == null)
                return;
            targetWeight.Text = target.Weight.ToString();
            targetWater.Text = target.Water.ToString();
            targetCalories.Text = target.Calories.ToString();
            targetDistacne.Text = target.Distance.ToString();
        }

        private void SetMeasurementTextBoxes()
        {
            if (measurement == null)
                return;
            currentWeight.Text = measurement?.Weight.ToString();
            currentWater.Text = measurement?.Water.ToString();
            currentCalories.Text = measurement?.Calories.ToString();
            currentDistance.Text = measurement?.Distance.ToString();
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            target.Weight = int.Parse(targetWeight.Text);
            target.Water = int.Parse(targetWater.Text);
            target.Calories = int.Parse(targetCalories.Text);
            target.Distance = int.Parse(targetDistacne.Text);

            db.Measurements.Add(new Measurement
            {
                Weight = int.Parse(currentWeight.Text),
                Water = int.Parse(currentWater.Text),
                Calories = int.Parse(currentCalories.Text),
                Distance = int.Parse(currentDistance.Text),
                DateTime = DateTime.Now
            });
            db.SaveChanges();
            saveButton.Content = "Zapisano";
            saveButton.IsEnabled = false;
        }

        private void TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
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
