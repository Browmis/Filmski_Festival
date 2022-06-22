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
        private string _username;
        private KonekcijaClass _connection;
        private Table _film;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string username, KonekcijaClass connection)
        {
            InitializeComponent();
            _username = username;
            _connection = connection;
            _film = new Table(_connection, "Film");
        }

        private void cbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectFilm();
        }

        private void cbxYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectFilm();
        }

        private void SelectFilm()
        {
            string[] forD = new string[] { "%", "%" };
            string genre = (cbxGenre.SelectedItem == null || cbxGenre.SelectedItem.ToString().Length == 0) ? "%" : cbxGenre.SelectedItem.ToString();
            string year = (cbxYear.SelectedItem == null || cbxYear.SelectedItem.ToString().Length == 0) ? "%" : cbxYear.SelectedItem.ToString();
            string film = (txtFilm.Text.Length == 0) ? "%" : "%" + txtFilm.Text.ToString() + "%";
            string[] director = (cbxDirector.SelectedItem == null || cbxDirector.SelectedItem.ToString().Length == 0) ? forD : cbxDirector.SelectedItem.ToString().Split(' ');
            string command = "SELECT title FROM DirectorFilm where genre Like '" + genre + "' and year Like '" + year + "' and title Like '" + film + "'" + " and firstName like '%" + director[0] + "%' and secondName like '%" + director[1] + "%'";
            DataSet _films = _film.Select(command);
            listFilms.Items.Clear();
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                listFilms.Items.Add(row[0].ToString());
            }
        }

        private void txtFilm_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectFilm();
        }        
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userProfile user = new userProfile(_username, _connection);
            user.Show();
            this.Close();
        }

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            string film  = listFilms.SelectedItem.ToString();
            Movie movie = new Movie(_connection, film, _username);
            movie.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BestMovies best = new BestMovies(_connection, _username);
            best.Show();
            this.Close();
        }

        private void cbxDirector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectFilm();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxGenre.Items.Add("");
            cbxYear.Items.Add("");
            cbxDirector.Items.Add("");
            _film.Open();
            string command = "SELECT DISTINCT genre FROM DirectorFilm";
            DataSet _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxGenre.Items.Add(row[0].ToString());
            }
            command = "SELECT DISTINCT year FROM DirectorFilm";
            _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxYear.Items.Add(row[0].ToString());
            }
            command = "SELECT DISTINCT firstName, secondName FROM DirectorFilm";
            _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    cbxDirector.Items.Add(row[0].ToString().Replace(" ", "").Replace("\r", "").Replace("\n", "") + " " + row[1].ToString().Replace(" ", ""));
            }
            command = "SELECT DISTINCT title FROM DirectorFilm";
            _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                    listFilms.Items.Add(row[0].ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            _film.Close();
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
