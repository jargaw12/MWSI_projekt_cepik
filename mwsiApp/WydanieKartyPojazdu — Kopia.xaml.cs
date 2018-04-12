using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace mwsiApp
{
    /// <summary>
    /// Logika interakcji dla klasy WydanieKartyPojazdu.xaml
    /// </summary>
    public partial class WydanieKartyPojazdu : Page
    {
        public WydanieKartyPojazdu()
        {
            InitializeComponent();
        }

        private async void comboBox_marka_Loaded(object sender, RoutedEventArgs e)
        {
            bd1Entities1 p = new bd1Entities1();
            List<Marka> marki = await Task.Run(() => p.Markas.ToList());
            comboBox_marka.ItemsSource = marki;
            comboBox_marka.DisplayMemberPath = "marka1";
            comboBox_marka.SelectedValuePath = "idMarka";
        }

        private async void comboBox_marka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int markaid = Convert.ToInt32(comboBox_marka.SelectedValue);
            bd1Entities1 p = new bd1Entities1();
            List<Model> modele = await Task.Run(() => p.Models.Where(x => x.idMarka == markaid).ToList());
            comboBox_model.ItemsSource = modele;
            comboBox_model.DisplayMemberPath = "model1";
            comboBox_model.SelectedValuePath = "idModel";
        }

        private async void comboBox_typNad_Loaded(object sender, RoutedEventArgs e)
        {
            bd1Entities1 p = new bd1Entities1();
            List<TypNadwozia> nadwozia = await Task.Run(() => p.TypNadwozias.ToList());
            comboBox_typNad.ItemsSource = nadwozia;
            comboBox_typNad.DisplayMemberPath = "typNadwozia1";
            comboBox_typNad.SelectedValuePath = "idTypNadwozia";
        }

        private async void comboBox_rodzPaliwa_Loaded(object sender, RoutedEventArgs e)
        {
            bd1Entities1 p = new bd1Entities1();
            List<RodzajPaliwa> paliwa = await Task.Run(() => p.RodzajPaliwas.ToList());
            comboBox_rodzPaliwa.ItemsSource = paliwa;
            comboBox_rodzPaliwa.DisplayMemberPath = "rodzajPaliwa1";
            comboBox_rodzPaliwa.SelectedValuePath = "idRodzajPaliwa";
        }

        private void btnWydanieKartPojazdu_Click(object sender, RoutedEventArgs e)
        {
            KartaPojazdu kartaPojazdu = new KartaPojazdu();
            kartaPojazdu.VIN = TextBox_VIN.Text;
            kartaPojazdu.idMarka = Convert.ToInt32(comboBox_marka.SelectedValue);
            kartaPojazdu.idModel = Convert.ToInt32(comboBox_model.SelectedValue);
            kartaPojazdu.idTypNadwozia = Convert.ToInt32(comboBox_typNad.SelectedValue);
            kartaPojazdu.liczbaMiejsc = Convert.ToInt32(textBox_liczMiejsc.Text);
            kartaPojazdu.idRodzajPaliwa = Convert.ToInt32(comboBox_rodzPaliwa.SelectedValue);
            kartaPojazdu.srZuzyciePaliwa = Convert.ToInt32(TextBox_srZuzPaliwa.Text);
            kartaPojazdu.pojemnosc = Convert.ToInt32(textBox_poj.Text);
            kartaPojazdu.mocSilnika = Convert.ToInt32(textBox_mocSilnika.Text);
            kartaPojazdu.masaWlasna = Convert.ToInt32(TextBox_masaW.Text);
            if (TextBox_ladownosc != null) kartaPojazdu.ladownosc = Convert.ToInt32(TextBox_ladownosc.Text);
            kartaPojazdu.dataWydaniaKartyPojazdu=DateTime.Now;

            bd1Entities1 b = new bd1Entities1();
            b.KartaPojazdus.Add(kartaPojazdu);
            b.SaveChanges();
            MessageBox.Show("Dodano kartę pojazdu");
    }
    }
}
