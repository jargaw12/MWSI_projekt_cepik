using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy DaneTechniczne.xaml
    /// </summary>
    public partial class DaneTechniczne
    {
        private readonly string nrVin;

        public DaneTechniczne(string vin)
        {
            nrVin = vin;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var x = await Task.Run(() => p.KartaPojazdus.Count(s => s.VIN == nrVin));
            if (x == 1)
            {
                var data = p.KartaPojazdus.Where(s => s.VIN == nrVin).ToList();
                TPojemnosc.Text = Convert.ToString(data[0].pojemnosc) + " cm^3";
                TMoc.Text = Convert.ToString(data[0].mocSilnika) + " kW";
                TPaliwo.Text = Convert.ToString(data[0].srZuzyciePaliwa) + " l";
                TLiczba.Text = Convert.ToString(data[0].liczbaMiejsc);
                TMasa.Text = Convert.ToString(data[0].masaWlasna) + " kg";
                TLadownosc.Text = Convert.ToString(data[0].ladownosc) + " kg";
            }
        }
    }
}