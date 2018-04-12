using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy OknoPolicjanta.xaml
    /// </summary>
    public partial class OknoPolicjanta
    {
        private readonly string a1 ="";
        private readonly string a2 ="";
        public OknoPolicjanta(string s11, string s22)
        {
            a1 = s11;
            a2 = s22;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            l_nazwa.Content = a1 + " " + a2;
        }
   

        private void Btn_wyloguj(object sender, RoutedEventArgs e)
        {
            var logowanie = new LogowanieWlasciciel();
            logowanie.Show();
            Close();
        }

        private void btn_informacje_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}