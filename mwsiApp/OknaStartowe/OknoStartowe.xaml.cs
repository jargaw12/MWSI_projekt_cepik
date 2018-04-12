using System.Windows;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnObywatel_Click(object sender, RoutedEventArgs e)
        {
            var logowanieWlasciciel = new LogowanieWlasciciel();
            logowanieWlasciciel.Show();
            Close();
        }

        private void btnPolicjant_Click(object sender, RoutedEventArgs e)
        {
            var logowaniePolicjant = new LogowaniePolicjant();
            logowaniePolicjant.Show();
            Close();
        }

        private void btnUrzednik_Click(object sender, RoutedEventArgs e)
        {
            var logowanieUrzednik = new LogowanieUrzednik();
            logowanieUrzednik.Show();
            Close();
        }
    }
}