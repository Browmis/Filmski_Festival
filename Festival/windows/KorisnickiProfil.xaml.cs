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

namespace Festival
{
    /// <summary>
    /// Interaction logic for userProfile.xaml
    /// </summary>
    public partial class userProfile : Window
    {
        private KonekcijaClass _connection;
        private string username;
        DataSet korisnik;
        Tabela table;
        public userProfile()
        {
            InitializeComponent();
        }
        public userProfile(string username, KonekcijaClass connection)
        {
            
            InitializeComponent();
            this.username = username;
            _connection = connection;
            table = new Tabela(_connection, "Korisnik");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            table.OtvoriKonekciju();
            string command = "SELECT * FROM [Korisnik] where korisnickoIme = '" + username + "'";
            korisnik = table.Select(command);
            idIme.Text = korisnik.Tables[0].Rows[0][1].ToString();
            idPrezime.Text = korisnik.Tables[0].Rows[0][2].ToString();
            idNickname.Text = korisnik.Tables[0].Rows[0][3].ToString();
            idEmail.Text = korisnik.Tables[0].Rows[0][5].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string command = "SELECT * FROM [Korisnik] where korisnickoIme = '" + username + "'";
            korisnik = table.Select(command);
            string staraSifra = korisnik.Tables[0].Rows[0][4].ToString();
            string ime = idIme.Text;
            string prezime = idPrezime.Text;
            string email = idEmail.Text;
            string nickname = idNickname.Text;
            string novaSifra = idNovaSifra.Password;
            string potvrdaSifre = idPotvrdaSifre.Password;
            if (ime != null || prezime != null || email != null || nickname != null || novaSifra != null || potvrdaSifre != null)
            {
                if(staraSifra == novaSifra)
                {
                    MessageBox.Show("Nova sifra ne moze biti ista kao stara", "GRESKA");
                }
                if (novaSifra != potvrdaSifre)
                {
                     MessageBox.Show("Sifre se ne podudaraju!", "GRESKA");
                }
                else
                {
                    command = "UPDATE [Korisnik] SET ime = '" + ime + "'," + "prezime = '" + prezime + "'," + "korisnickoIme= '" + nickname + "'," + "sifra= '" + novaSifra + "'," + "email= '" + email + "'" + "WHERE korisnickoIme= '" + username + "';";
                    table.Azuriranje(command);
                    MessageBox.Show("Uspesno ste promenili podatke", "Poruka");
                    userProfile profile = new userProfile(username, _connection);
                    profile.Show();
                    this.Close();
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            windows.Menu meni = new windows.Menu(username, _connection);
            meni.Show();
            this.Close();
        }
    }
}
