using DBUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Festival.windows
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string korisnickoIme;
        private KonekcijaClass konekcija;
        private Tabela _film;
        string komanda;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string korisnickoIme, KonekcijaClass connection)
        {
            InitializeComponent();
            this.korisnickoIme = korisnickoIme;
            konekcija = connection;
            _film = new Tabela(konekcija, "Film");
        }

        private void cbxzanr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelektujFilm();
        }

        private void cbxgodina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelektujFilm();
        }

        private void SelektujFilm()
        {
            string[] forD = new string[] { "%", "%" };
            string genre = (cbxzanr.SelectedItem == null || cbxzanr.SelectedItem.ToString().Length == 0) ? "%" : cbxzanr.SelectedItem.ToString();
            string year = (cbxgodina.SelectedItem == null || cbxgodina.SelectedItem.ToString().Length == 0) ? "%" : cbxgodina.SelectedItem.ToString();
            string film = (txtFilm.Text.Length == 0) ? "%" : "%" + txtFilm.Text.ToString() + "%";
            string[] director = (cbxreziser.SelectedItem == null || cbxreziser.SelectedItem.ToString().Length == 0) ? forD : cbxreziser.SelectedItem.ToString().Split(' ');
            komanda = "SELECT naziv FROM ReziserFilm where zanr Like '" + genre + "' and godina Like '" + year + "' and naziv Like '" + film + "'" + " and ime like '%" + director[0] + "%' and prezime like '%" + director[1] + "%'";
            DataSet filmovi = _film.Select(komanda);
            listFilms.Items.Clear();
            foreach (DataRow row in filmovi.Tables[0].Rows)
            {
                listFilms.Items.Add(row[0].ToString());
            }
        }

        private void txtFilm_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelektujFilm();
        }        
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userProfile user = new userProfile(korisnickoIme, konekcija);
            user.Show();
            this.Close();
        }

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            string film  = listFilms.SelectedItem.ToString();
            Movie movie = new Movie(konekcija, film, korisnickoIme);
            movie.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BestMovies best = new BestMovies(konekcija, korisnickoIme);
            best.Show();
            this.Close();
        }

        private void cbxreziser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelektujFilm();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxzanr.Items.Add("");
            cbxgodina.Items.Add("");
            cbxreziser.Items.Add("");
            _film.OtvoriKonekciju();
            komanda = "SELECT DISTINCT zanr FROM ReziserFilm";
            DataSet _films = _film.Select(komanda);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxzanr.Items.Add(row[0].ToString());
            }
            komanda = "SELECT DISTINCT godina FROM ReziserFilm";
            _films = _film.Select(komanda);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxgodina.Items.Add(row[0].ToString());
            }
            komanda = "SELECT DISTINCT ime, prezime FROM ReziserFilm";
            _films = _film.Select(komanda);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxreziser.Items.Add(row[0].ToString().Replace(" ", "").Replace("\r", "").Replace("\n", "") + " " + row[1].ToString().Replace(" ", ""));
            }
            komanda = "SELECT DISTINCT naziv FROM ReziserFilm";
            _films = _film.Select(komanda);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    listFilms.Items.Add(row[0].ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            _film.ZatvoriKonekciju();
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
