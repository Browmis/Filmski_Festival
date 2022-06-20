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
        private Table _film;
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
            _film = new Table(_connection, "Film");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            windows.Menu menu = new windows.Menu(_username, _connection);
            menu.Show();
            this.Close();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            _film.Open();
            string command = "SELECT * From Film WHERE title = '" + _movie + "'";
            DataSet _films = _film.Select(command);
            foreach (DataRow row in _films.Tables[0].Rows)
            {
                listFilms.Items.Add("Title: " + row[1].ToString()); 
                listFilms.Items.Add("Duration: " + row[2].ToString()); 
                listFilms.Items.Add("Language: " + row[3].ToString()); 
                listFilms.Items.Add("Country: " + row[4].ToString()); 
                listFilms.Items.Add("Rating" + row[5].ToString()); 
                listFilms.Items.Add("Year: " + row[6].ToString()); 
                listFilms.Items.Add("Story line: " + row[7].ToString());
                listFilms.Items.Add("Genre: " + row[8].ToString());
            }
        }
    }
}
