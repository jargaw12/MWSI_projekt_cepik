using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy WyjerestrowaniePojazdu.xaml
    /// </summary>
    public partial class WyjerestrowaniePojazdu
    {
        public WyjerestrowaniePojazdu()
        {
            InitializeComponent();
        }

        private void btnRejestracjaUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            var b = new bd1Entities2();
        }

        private async void btnWyrejestrujPojazd_Click(object sender, RoutedEventArgs e)
        {
            var nr = TextBox_nrRej.Text;
            var b = new bd1Entities2();
            var dowod = await Task.Run(() =>
                b.DowodRejestracyjnies.Where(x => x.idDowodRejestracyjny == nr).DefaultIfEmpty().Single());
            if (dowod != null)
            {
                var vin = dowod.VIN;
                var pojazd = await Task.Run(() => b.Pojazds.Where(x => x.VIN == vin).DefaultIfEmpty().Single());
                pojazd.zarejestrowany = false;
                b.SaveChanges();
                MessageBox.Show("Wyrejestrowano pojazd");
            }
            else
            {
                MessageBox.Show("Operacja nie powiodła się!");
            }
        }
    }
}