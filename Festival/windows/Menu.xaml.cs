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

        private void Window_Activated(object sender, EventArgs e)
        {
            _film.Open();
            string command = "SELECT DISTINCT genre, year FROM Film";
            DataSet _genresAndYears = _film.Select(command);
            foreach (DataRow row in _genresAndYears.Tables[0].Rows)
            {
                if(row[0].ToString().Length > 0)
                    cbxGenre.Items.Add(row[0].ToString());
                if (row[1].ToString().Length > 0)
                    cbxYear.Items.Add(row[1].ToString());
            }
            command = "SELECT * From Film";
            DataSet _films = _film.Select(command);
            foreach(DataRow row in _films.Tables[0].Rows)
            {
                listFilms.Items.Add(row[1].ToString());
            }
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
            string genre = (cbxGenre.SelectedItem == null) ? "%" : cbxGenre.SelectedItem.ToString();
            string year = (cbxYear.SelectedItem == null) ? "%" : cbxYear.SelectedItem.ToString();
            string film = (txtFilm.Text.Length == 0) ? "%" : "%" + txtFilm.Text.ToString() + "%";
            string command = "SELECT * FROM Film where genre Like '" + genre + "' and year Like '" + year + "' and title Like '" + film + "'";
            DataSet _films = _film.Select(command);
            listFilms.Items.Clear();
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                listFilms.Items.Add(row[1].ToString());
            }
        }

        private void txtFilm_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectFilm();
            _connection = connection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userProfile user = new userProfile(_username, _connection);
            user.Show();
            this.Close();
        }
    }
}
