using DBUtils;
using Festival.windows;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Menu = Festival.windows.Menu;

namespace Festival
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KonekcijaClass _connection;
        private Table _user;
        public MainWindow()
        {
            InitializeComponent();
            _connection = new KonekcijaClass(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _user = new Table(_connection, "User");
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string command = "SELECT * FROM [User] WHERE username = '" + txtUsername.Text.ToString() + "' AND password = '" + txtPassword.Password.ToString() + "'";
            _user.Open();
            DataSet users = _user.Select(command);
            if (users.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Not correct username or password", "Error");
            }
            else
            {
                MessageBox.Show("All ok", "Accept");
                Menu _menu = new Menu(txtUsername.Text.ToString());
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Registracion _reg = new Registracion(_connection, _user);
            _reg.Show();
            this.Close();
        }
    }
}
