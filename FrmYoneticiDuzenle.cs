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
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtotmasyonDataSet4.admin' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.adminTableAdapter.Fill(this.yurtOtotmasyonDataSet4.admin);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into admin (yoneticiAd, yoneticiSifre) values (@yoneticiAd, @yoneticiSifre)", bgl.baglanti());
            komut.Parameters.AddWithValue("@yoneticiAd", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@yoneticiSifre", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Eklendi");
            this.adminTableAdapter.Fill(this.yurtOtotmasyonDataSet4.admin);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre, id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txtKullaniciAd.Text = ad;
            txtSifre.Text = sifre;
            txtYoneticiId.Text = id;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from admin where yoneticiId=@yoneticiId", bgl.baglanti());
            komut.Parameters.AddWithValue("@yoneticiId", txtYoneticiId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Silindi");
            this.adminTableAdapter.Fill(this.yurtOtotmasyonDataSet4.admin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update admin set yoneticiAd=@yoneticiAd, yoneticiSifre=@yoneticiSifre where yoneticiId=@yoneticiId", bgl.baglanti());
            komut.Parameters.AddWithValue("@yoneticiAd", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@yoneticiSifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@yoneticiId", txtYoneticiId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme Gerçekleşti");
            this.adminTableAdapter.Fill(this.yurtOtotmasyonDataSet4.admin);

        }

        private void txtYoneticiId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
