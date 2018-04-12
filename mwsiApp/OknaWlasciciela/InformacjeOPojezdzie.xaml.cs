using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy InformacjeOPojezdzie.xaml
    /// </summary>
    public partial class InformacjeOPojezdzie : Page
    {
        private readonly string nrVin;

        public InformacjeOPojezdzie(string vin)
        {
            nrVin = vin;
            InitializeComponent();
        }

        private async void Win_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var x = await Task.Run(() => p.KartaPojazdus.Count(s => s.VIN == nrVin));
            if (x == 1)
            {
                var data = p.KartaPojazdus.Where(s => s.VIN == nrVin).ToList();
                var idMarka = data[0].idMarka;
                if (idMarka != null)
                {
                    var s1 = idMarka.Value;
                    var idModel = data[0].idModel;
                    if (idModel != null)
                    {
                        var s2 = idModel.Value;
                        var s3 = data[0].idRodzajPaliwa;
                        var s4 = data[0].idTypNadwozia;
                        tMarka.Text = p.Markas.Where(s => s.idMarka == s1).ToList()[0].marka1;
                        tModel.Text = p.Models.Where(s => s.idModel == s2).ToList()[0].model1;
                        tNadwozie.Text = p.TypNadwozias.Where(s => s.idTypNadwozia == s4).ToList()[0].typNadwozia1;
                        tPaliwo.Text = p.RodzajPaliwas.Where(s => s.idRodzajPaliwa == s3).ToList()[0].rodzajPaliwa1;
                    }
                }

                tStatus.Text = data[0].dataPierwszejRejestracji != null ? "zarejestrowany" : "niezarejestrowany";
            }
        }
    }
}