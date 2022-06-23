using DBUtils;
using Festival.windows;
using System.Configuration;
using System.Data;
using System.Windows;
using Menu = Festival.windows.Menu;

namespace Festival
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KonekcijaClass konekcija;
        private Tabela korisnik;
        public MainWindow()
        {
            InitializeComponent();
            konekcija = new KonekcijaClass(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            korisnik = new Tabela(konekcija, "Korisnik");
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            string komanda = "SELECT * FROM [Korisnik] WHERE korisnickoIme = '" + txtKorisnickoIme.Text.ToString() + "' AND sifra = '" + txtSifra.Password.ToString() + "'";
            korisnik.OtvoriKonekciju();
            DataSet users = korisnik.Select(komanda);
            if (users.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Not correct username or password", "Error");
            }
            else
            {
                Menu _menu = new Menu(txtKorisnickoIme.Text.ToString(), konekcija);
                _menu.Show();
                this.Close();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Registracion _reg = new Registracion(konekcija, korisnik);
            _reg.Show();
            this.Close();
        }
    }
}
