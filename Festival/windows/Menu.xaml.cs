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

namespace Festival.windows
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string _username;
        private KonekcijaClass _connection;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string username, KonekcijaClass connection)
        {
            InitializeComponent();
            _username = username;
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
