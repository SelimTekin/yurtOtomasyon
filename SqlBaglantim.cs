using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace yurtOtomasyon
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=SELIM\SQLEXPRESS;Initial Catalog=yurtOtotmasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
