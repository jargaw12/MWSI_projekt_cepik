namespace mwsiApp
{
    /// <summary>
    ///     Logika interakcji dla klasy HistoriaPojazdu.xaml
    /// </summary>
    public partial class HistoriaPojazdu
    {
        private string nrVin;

        public HistoriaPojazdu(string vin)
        {
            nrVin = vin;
            InitializeComponent();
        }
    }
}