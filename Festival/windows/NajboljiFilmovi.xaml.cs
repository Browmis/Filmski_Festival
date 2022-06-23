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
    /// Interaction logic for BestMovies.xaml
    /// </summary>
    public partial class BestMovies : Window
    {
        private KonekcijaClass _connection;
        private string _username;
        private Tabela _film;
        private string command;
        public BestMovies()
        {
            InitializeComponent();
        }
        public BestMovies(KonekcijaClass connection, string username)
        {
            InitializeComponent();
            _connection = connection;
            _username = username;
            _film = new Tabela(_connection, "Film");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            command = "SELECT DISTINCT godina FROM Film";
            DataSet year = _film.Select(command);
            foreach (DataRow row in year.Tables[0].Rows)
            {
                if (row[0].ToString().Length > 0)
                {
                    cbYear.Items.Add(row[0].ToString());
                }
            }
        }

        private void cbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listFilms.Items.Clear();
            string g = cbYear.SelectedItem.ToString();
            int godina = Int32.Parse(g);
            string command = "SELECT naziv, ocena From Film WHERE godina = " + godina + "ORDER BY ocena DESC";
            DataSet grades = _film.Select(command);
            foreach (DataRow row in grades.Tables[0].Rows)
            {
                listFilms.Items.Add(row[0].ToString() + row[1].ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            windows.Menu meni = new windows.Menu(_username, _connection);
            meni.Show();
            this.Close();

        }
    }
}
