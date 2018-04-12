using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy OknoWlasciciela.xaml
    /// </summary>
    public partial class LogowanieWlasciciel
    {
        public LogowanieWlasciciel()
        {
            InitializeComponent();
        }

        private async void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            if (tb_pesel.Text != "" && pb_vin.Text != "")
            {
                var pesel = tb_pesel.Text;
                var vin = pb_vin.Text;
                img_loading.Visibility = Visibility.Visible;
                var p = new bd1Entities2();
                var x = await Task.Run(
                    () => p.DowodRejestracyjnies.Count(s => s.PESEL == pesel && s.VIN == vin));
                if (x == 1)
                {
                    var oknoUrzednika = new OknoWlasciciela(pesel, vin);
                    img_loading.Visibility = Visibility.Hidden;
                    oknoUrzednika.Show();
                    Close();
                }
                else
                {
                    img_loading.Visibility = Visibility.Hidden;
                    MessageBox.Show("Niepoprawny PESEL lub VIN");
                }
            }
        }

        private void tb_nazwa_pmd(object sender, MouseButtonEventArgs e)
        {
        }


        private void pb_haslo_pmd(object sender, MouseButtonEventArgs e)
        {
        }

        private void btn_powrot(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }
    }
}