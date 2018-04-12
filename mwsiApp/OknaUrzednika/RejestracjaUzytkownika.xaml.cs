using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy RejestracjaUzytkownika.xaml
    /// </summary>
    public partial class RejestracjaUzytkownika
    {
        public RejestracjaUzytkownika()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void ComboBox_woj_Loaded(object sender, RoutedEventArgs e)
        {
            var p = new bd1Entities2();
            var woj = await Task.Run(() => p.Wojewodztwoes.ToList());
            comboBox_woj.ItemsSource = woj;
            comboBox_woj.DisplayMemberPath = "wojewodztwo1";
            comboBox_woj.SelectedValuePath = "idWojewodztwo";
        }


        private async void ComboBox_woj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var wojId = Convert.ToInt32(comboBox_woj.SelectedValue);
            var p = new bd1Entities2();
            var powiat = await Task.Run(() => p.Powiats.Where(x => x.idWojewodztwo == wojId).ToList());
            comboBox_powiat.ItemsSource = powiat;
            comboBox_powiat.DisplayMemberPath = "powiat1";
            comboBox_powiat.SelectedValuePath = "idPowiat";
        }


        private async void ComboBox_powiat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var powId = Convert.ToInt32(comboBox_powiat.SelectedValue);
            var p = new bd1Entities2();
            var miejsc = await Task.Run(() => p.Miejscowoscs.Where(x => x.idPowiat == powId).ToList());
            comboBox_miejsc.ItemsSource = miejsc;
            comboBox_miejsc.DisplayMemberPath = "miejscowosc1";
            comboBox_miejsc.SelectedValuePath = "idMiejscowosc";
        }

        private void BtnRejestracjaUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            var uzytkownik = new Uzytkownik();
            try
            {
                uzytkownik.PESEL = TextBox_PESEL.Text;
                uzytkownik.nazwisko = textBox_nazwisko.Text;
                uzytkownik.imie = TextBox_imie.Text;
                uzytkownik.imie2 = TextBox_imie2.Text;
                uzytkownik.idWojewodztwo = Convert.ToInt32(comboBox_woj.SelectedValue);
                uzytkownik.idPowiat = Convert.ToInt32(comboBox_powiat.SelectedValue);
                uzytkownik.idMiejscowosc = Convert.ToInt32(comboBox_miejsc.SelectedValue);
                uzytkownik.ulica = TextBox_ul.Text;
                //if (uzytkownik.nrDomu!=null)
                {
                    uzytkownik.nrDomu = Convert.ToInt32(TextBox_nrDom.Text);
                }
                //if (uzytkownik.nrLokalu != null)
                {
                    uzytkownik.nrLokalu = Convert.ToInt32(TextBox_nrLok.Text);
                }
                //uzytkownik.miejsceUrodzenia = textBox_miejscUr.Text;
                //if (uzytkownik.dataUrodzenia != null)
                {
                    uzytkownik.dataUrodzenia = Convert.ToDateTime(DataPicker_dataUr.Text);
                }
                uzytkownik.telefon = textBox_tel.Text;
                uzytkownik.login = uzytkownik.PESEL;
                uzytkownik.haslo = "haslo1234";
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane");
                //throw;
            }

            try
            {
                var b = new bd1Entities2();
                b.Uzytkowniks.Add(uzytkownik);
                b.SaveChanges();
                MessageBox.Show(
                    "Zarejestrowano uzytkownika. Login: " + uzytkownik.login + " Hasło: " + uzytkownik.haslo);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Nie udało się dodać uzytkownika");
                //throw;
            }
        }
    }
}