using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy OknoWlasciciela.xaml
    /// </summary>
    public partial class OknoWlasciciela
    {
        private readonly string pesel;
        private readonly string vin;

        public OknoWlasciciela(string pesel1, string vin1)
        {
            pesel = pesel1;
            vin = vin1;
            InitializeComponent();
        }

        private void btn_historia_Click(object sender, RoutedEventArgs e)
        {
            Page page = new HistoriaPojazdu(vin);
            myFrame.NavigationService.Navigate(page);
            p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void btn_dokumenty_Click(object sender, RoutedEventArgs e)
        {
            p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            Page page = new InformacjeODokumentach(vin);
            myFrame.NavigationService.Navigate(page);
        }

        private void btn_informacje_Click(object sender, RoutedEventArgs e)
        {
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p1.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            Page page = new InformacjeOPojezdzie(vin);
            myFrame.NavigationService.Navigate(page);
        }

        private void btn_daneTechniczne_Click(object sender, RoutedEventArgs e)
        {
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));

            Page page = new DaneTechniczne(vin);
            myFrame.NavigationService.Navigate(page);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var x = await Task.Run(() => p.Uzytkowniks.Count(s => s.PESEL == pesel));
            if (x == 1)
            {
                var data = p.Uzytkowniks.Where(s => s.PESEL == pesel).ToList();
                var s1 = data[0].imie;
                var s2 = data[0].nazwisko;
                l_nazwa.Content = s1 + " " + s2;
            }
        }

        private void Btn_wyloguj(object sender, RoutedEventArgs e)
        {
            var logowanie = new LogowanieWlasciciel();
            logowanie.Show();
            Close();
        }
    }
}