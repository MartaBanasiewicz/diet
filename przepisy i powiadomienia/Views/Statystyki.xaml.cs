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
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WinRTXamlToolkit.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace przepisy_i_powiadomienia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Statystyki : Page
    {
        public Statystyki()
        {
            this.InitializeComponent();
            LoadData();
            UpdateCharts();
        }

        private PoradnikContext db = new PoradnikContext();
        private Random _random = new Random();
        private List<Measurement> measurements;
        List<NameValueItem> weightValues = new List<NameValueItem>();
        List<NameValueItem> waterValues = new List<NameValueItem>();
        List<NameValueItem> caloriesValues = new List<NameValueItem>();
        List<NameValueItem> distanceValues = new List<NameValueItem>();

        private void LoadData()
        {
            measurements = db.Measurements.OrderBy(x => x.DateTime).ToList();
            foreach (var measurement in measurements)
            {
                weightValues.Add(new NameValueItem { Name = measurement.DateTime.ToString(), Value = measurement.Weight });
                waterValues.Add(new NameValueItem { Name = measurement.DateTime.ToString(), Value = measurement.Water });
                caloriesValues.Add(new NameValueItem { Name = measurement.DateTime.ToString(), Value = measurement.Calories});
                distanceValues.Add(new NameValueItem { Name = measurement.DateTime.ToString(), Value = measurement.Distance });
            }
        }


        private void UpdateCharts()
        {
            UpdateChart(weight, weightValues);
            UpdateChart(water, waterValues);
            UpdateChart(calories, caloriesValues);
            UpdateChart(distance, distanceValues);
        }

        private void UpdateChart(Chart chart, IEnumerable<NameValueItem> values)
        {
            ((LineSeries)chart.Series[0]).ItemsSource = values;
            ((LineSeries)chart.Series[0]).DependentRangeAxis =
                new LinearAxis
                {
                    Minimum = values.Min(x => x.Value),
                    Maximum = values.Max(x => x.Value),
                    Orientation = AxisOrientation.Y,
                    Interval = (values.Max(x => x.Value) - values.Min(x => x.Value))/5D,
                    ShowGridLines = true
                };
        }

        public class NameValueItem
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
