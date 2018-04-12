using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy OknoUrzednika.xaml
    /// </summary>
    public partial class OknoUrzednika
    {
        private readonly string imie;
        private readonly string nazwisko;

        public OknoUrzednika(string imie1, string nazwisko1)
        {
            imie = imie1;
            nazwisko = nazwisko1;
            InitializeComponent();
        }

        private void BtnRejestracjaUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            //p1.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            Page page = new RejestracjaUzytkownika();
            myFrame.NavigationService.Navigate(page);
            p2.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void BtnKartaPojazdu_Click(object sender, RoutedEventArgs e)
        {
            p2.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            Page page = new WydanieKartyPojazdu();
            myFrame.NavigationService.Navigate(page);
            //p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void Btn_RejestracjaPojazdu_Click(object sender, RoutedEventArgs e)
        {
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            Page page = new RejestracjaPojazdu();
            myFrame.NavigationService.Navigate(page);
            //p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p2.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void BtnWyrejestrowanie_Click(object sender, RoutedEventArgs e)
        {
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 57, 220, 163));
            Page page = new WyjerestrowaniePojazdu();
            myFrame.NavigationService.Navigate(page);
            //p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p2.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void BtnPrzeniesienie_Click(object sender, RoutedEventArgs e)
        {
            Page page = new PrzeniesienieWlasnosciPojazdu();
            myFrame.NavigationService.Navigate(page);
            //p1.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p2.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p3.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
            p4.Fill = new SolidColorBrush(Color.FromArgb(100, 44, 62, 80));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            l_nazwa.Content = imie + " " + nazwisko;
        }

        private void Btn_wyloguj(object sender, RoutedEventArgs e)
        {
            var logowanie = new LogowanieWlasciciel();
            logowanie.Show();
            Close();
        }
    }
}