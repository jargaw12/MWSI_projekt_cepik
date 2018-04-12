using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy LogowanieUrzednik.xaml
    /// </summary>
    public partial class LogowanieUrzednik
    {
        public LogowanieUrzednik()
        {
            InitializeComponent();
        }

        private async void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            if (tb_nazwa.Text != "" && pb_haslo.Password != "")
            {
                var name = tb_nazwa.Text;
                var password = pb_haslo.Password;
                img_loading.Visibility = Visibility.Visible;
                var p = new bd1Entities2();
                var x = await Task.Run(() => p.Urzedniks.Count(s => s.login == name && s.haslo == password));
                if (x == 1)
                {
                    var data = p.Urzedniks.Where(s => s.login == tb_nazwa.Text).ToList();
                    var s1 = data[0].imie;
                    var s2 = data[0].nazwisko;
                    var oknoUrzednika = new OknoUrzednika(s1, s2);
                    img_loading.Visibility = Visibility.Hidden;
                    oknoUrzednika.Show();
                    Close();
                }
                else
                {
                    img_loading.Visibility = Visibility.Hidden;
                    MessageBox.Show("Niepoprawny login lub hasło");
                }
            }
        }

        private void tb_nazwa_pmd(object sender, MouseButtonEventArgs e)
        {
        }

        private void btn_powrot(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }
    }
}