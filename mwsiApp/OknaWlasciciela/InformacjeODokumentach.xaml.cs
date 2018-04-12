using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy InformacjeODokumentach.xaml
    /// </summary>
    public partial class InformacjeODokumentach
    {
        private readonly string nrVin;

        public InformacjeODokumentach(string vin)
        {
            nrVin = vin;
            InitializeComponent();
        }

        private async void Win_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var x = await Task.Run(() => p.Pojazds.Count(s => s.VIN == nrVin));
            if (x == 1)
            {
                var data = p.KartaPojazdus.Where(s => s.VIN == nrVin).ToList();
                tDR.Text = Convert.ToString(data[0].dataPierwszejRejestracji);
                tKP.Text = Convert.ToString(data[0].dataWydaniaKartyPojazdu);
            }
        }
    }
}