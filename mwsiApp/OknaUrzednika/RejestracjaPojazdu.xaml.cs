using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy RejestracjaPojazdu.xaml
    /// </summary>
    public partial class RejestracjaPojazdu
    {
        public RejestracjaPojazdu()
        {
            InitializeComponent();
        }

        private async void BtnRejestracjaPojazdu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var b = new bd1Entities2();
                var dowod = new DowodRejestracyjny
                {
                    idDowodRejestracyjny = TextBox_nrRejestracyjny.Text,
                    PESEL = TextBox_PESEL.Text,
                    VIN = TextBox_VIN.Text,
                    dataWydania = DateTime.Today.Date
                };
                b.DowodRejestracyjnies.Add(dowod);
                b.SaveChanges();

                var vin = TextBox_VIN.Text;
                var pojazd = await Task.Run(() => b.Pojazds.Where(x => x.VIN == vin).DefaultIfEmpty().Single());
                if (pojazd != null)
                {
                    pojazd.zarejestrowany = true;
                    pojazd.dataAktualnegoDR = DateTime.Today.Date;
                    b.SaveChanges();
                    MessageBox.Show("Zarejestrowano pojazd");
                }
                else
                {
                    MessageBox.Show("Operacja nie udała się!");
                }
            }
            catch (DbEntityValidationException exception)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane!");
            }


//            bd1Entities2 b = new bd1Entities2();
//            List<Pojazd> pojazd = await Task.Run(() => b.Pojazds.ToList());
//            int x = 0;
        }


        /*      private void textBox_postCode_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
              {
                  Regex regex = new Regex("[^0-9]{2}-[0-9]{3}");
                  if (regex.IsMatch(textBox_postCode.Text))
                  {
                      MessageBox.Show("Invalid Input !");
                  }
              }

              private void textBox_Copy2_LostFocus(object sender, RoutedEventArgs e)
              {
                  TextBox _target = sender as TextBox;
                  Regex regex = new Regex("^[0-9]{0,4}$");
                  if (!regex.IsMatch(_target.Text))
                  {
                      rokProdukcjiVal.Text = "Musisz wprowadzić liczbę";
                      textBox_Copy2.BorderBrush = new SolidColorBrush(Colors.Red);
                      e.Handled = true;

                  }
                  else
                  {
                      rokProdukcjiVal.Text = "";
                      textBox_Copy2.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
                  }
              }*/
    }
}