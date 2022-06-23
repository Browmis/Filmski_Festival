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
        Tabela _table;
        public Registracion()
        {
            InitializeComponent();
        }
        public Registracion(KonekcijaClass connection, Tabela table)
        {
            InitializeComponent();
            _connection = connection;
            _table = table;
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text.Length == 0 || txtEMail.Text.Length == 0 || txtPass.Password.Length == 0 || txtCPass.Password.Length == 0)
            {
                MessageBox.Show("Unesite sve podatke", "Greška");
            }
            else
            {
                if(txtPass.Password != txtCPass.Password)
                {
                    MessageBox.Show("Šifre se ne podudaraju", "Greška");
                }
                else
                {
                    _table.OtvoriKonekciju();
                    string command = "SELECT* FROM[Korisnik] WHERE korisnickoIme = '" + txtUser.Text.ToString() + "' OR email = '" + txtEMail.Text.ToString() + "'";
                    if(_table.Select(command).Tables[0].Rows.Count != 0)
                    {
                        MessageBox.Show("Korisničko ime ili email već postoji", "greška");
                    }
                    else
                    {
                        command = "INSERT INTO [Korisnik] VALUES('" + txtName.Text.ToString() + "','" + txtLName.Text.ToString() + "','" + txtUser.Text.ToString() + "','" + txtPass.Password.ToString() + "','" + txtEMail.Text.ToString() + "')";
                        if(_table.Azuriranje(command))
                        {
                            MessageBox.Show("Registracije je uspešna", "poruka");
                            MainWindow window = new MainWindow();
                            window.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registracija nije uspešna", "Greška");
                        }
                    }
                }
            }
        }
    }
}
