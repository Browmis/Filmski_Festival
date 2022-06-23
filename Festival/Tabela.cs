using DBUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival
{
    public class Tabela : TabelaClass
    {
        private KonekcijaClass _konekcija;
        public Tabela(KonekcijaClass konekcijaParametar, string nazivTabeleParametar) : base(konekcijaParametar, nazivTabeleParametar)
        {
            _konekcija = konekcijaParametar;
        }
        public bool OtvoriKonekciju()
        {
            return _konekcija.OtvoriKonekciju();
        }
        public void ZatvoriKonekciju()
        {
            _konekcija.ZatvoriKonekciju();
        }
        public SqlConnection DajKonekciju()
        {
            return _konekcija.DajKonekciju();
        }
        public DataSet Select(string komanda)
        {
            return DajPodatke(komanda);
        }
        public bool Azuriranje(string komanda)
        {
            return IzvrsiAzuriranje(komanda);
        }
    }
}
