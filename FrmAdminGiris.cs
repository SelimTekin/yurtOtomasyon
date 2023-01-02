using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yurtOtomasyon
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from admin where yoneticiAd=@yoneticiAd and yoneticiSifre=@yoneticiSifre", bgl.baglanti());
            komut.Parameters.AddWithValue("@yoneticiAd", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@yoneticiSifre", txtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                txtKullaniciAd.Clear();
                txtSifre.Clear();
                txtKullaniciAd.Focus();
            }

            bgl.baglanti().Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
