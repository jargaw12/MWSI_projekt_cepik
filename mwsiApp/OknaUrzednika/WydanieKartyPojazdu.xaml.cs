using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy WydanieKartyPojazdu.xaml
    /// </summary>
    public partial class WydanieKartyPojazdu
    {
        public WydanieKartyPojazdu()
        {
            InitializeComponent();
        }

        private async void comboBox_marka_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var marki = await Task.Run(() => p.Markas.ToList());
        }

        private void comboBox_marka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void comboBox_typNad_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void comboBox_rodzPaliwa_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void btnWydanieKartPojazdu_Click(object sender, RoutedEventArgs e)
        {
            var vin = TextBox_VIN.Text;
            var p = new bd1Entities2();
            var karta = await Task.Run(() => p.KartaPojazdus.Where(x => x.VIN == vin).DefaultIfEmpty().Single());
            if (karta != null)
            {
                karta.wydano = true;
                p.SaveChanges();
                MessageBox.Show("Wydano kartę pojazdu");
            }
            else
            {
                MessageBox.Show("Operacja nie udała się!");
            }
        }
    }
}