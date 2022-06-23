using DBUtils;
using System;
using System.Collections.Generic;
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
using System.Data;

namespace Festival
{
    /// <summary>
    /// Interaction logic for Movie.xaml
    /// </summary>
    public partial class Movie : Window
    {
        private KonekcijaClass _connection;
        private string _username;
        private string _movie;
        private Tabela _film;
        public Movie()
        {
            InitializeComponent();
        }
        public Movie(KonekcijaClass connection, string movie, string username)
        {
            InitializeComponent();
            _connection = connection;
            _movie = movie;
            _username = username;
            _film = new Tabela(_connection, "Film");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            windows.Menu menu = new windows.Menu(_username, _connection);
            menu.Show();
            this.Close();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            _film.OtvoriKonekciju();
            string command = "SELECT * From Film WHERE naziv = '" + _movie + "'";
            DataSet _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                listFilms.Items.Add("Naziv: " + row[1].ToString()); 
                listFilms.Items.Add("Trajanje: " + row[2].ToString()); 
                listFilms.Items.Add("Jezik: " + row[3].ToString()); 
                listFilms.Items.Add("Zemlja: " + row[4].ToString()); 
                listFilms.Items.Add("Rating: " + row[5].ToString()); 
                listFilms.Items.Add("Godina: " + row[6].ToString()); 
                listFilms.Items.Add("Opis: " + row[7].ToString());
                listFilms.Items.Add("Žanr: " + row[8].ToString());
                listFilms.Items.Add("Ocena: " + row[9].ToString());
            }
            if(_films.Tables[0].Rows[0][6].ToString() == DateTime.Now.Year.ToString())
            {
                btVote.Visibility = Visibility.Visible;
            }
        }

        private void btVote_Click(object sender, RoutedEventArgs e)
        {
         
            string command = "SELECT ocena FROM Film WHERE naziv = '" + _movie + "'";
            DataSet _films = _film.Select(command);
            int grade = (_films.Tables[0].Rows[0][0] == null) ? 0 : Convert.ToInt32(_films.Tables[0].Rows[0][0]);
            grade++;
            command = "UPDATE Film SET ocena= " + grade  + "WHERE naziv = '" + _movie + "'";
            _film.Azuriranje(command);
        }
    }
}
