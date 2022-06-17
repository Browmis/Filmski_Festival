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
    /// Логика взаимодействия для Registracion.xaml
    /// </summary>
    public partial class Registracion : Window
    {
        private KonekcijaClass _connection;
        Table _table;
        public Registracion()
        {
            InitializeComponent();
        }
        public Registracion(KonekcijaClass connection, Table table)
        {
            InitializeComponent();
            _connection = connection;
            _table = table;
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text.Length == 0 || txtEMail.Text.Length == 0 || txtPass.Password.Length == 0 || txtCPass.Password.Length == 0)
            {
                MessageBox.Show("Please, insert your data", "Error");
            }
            else
            {
                if(txtPass.Password != txtCPass.Password)
                {
                    MessageBox.Show("Passwords do not match", "Error");
                }
                else
                {
                    _table.Open();
                    string command = "SELECT* FROM[User] WHERE username = '" + txtUser.Text.ToString() + "' OR email = '" + txtEMail.Text.ToString() + "'";
                    if(_table.Select(command).Tables[0].Rows.Count != 0)
                    {
                        MessageBox.Show("Username or email already exists", "Error");
                    }
                    else
                    {
                        command = "INSERT INTO [User] VALUES('" + txtName.Text.ToString() + "','" + txtLName.Text.ToString() + "','" + txtUser.Text.ToString() + "','" + txtPass.Password.ToString() + "','" + txtEMail.Text.ToString() + "')";
                        if(_table.Azuriranje(command))
                        {
                            MessageBox.Show("Registration has been completed successfuly", "info");
                            MainWindow window = new MainWindow();
                            window.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registration has not been completed", "Error");
                        }
                    }
                }
            }
        }
    }
}
