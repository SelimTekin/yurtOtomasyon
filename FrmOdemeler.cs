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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtotmasyonDataSet2.borclar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclarTableAdapter.Fill(this.yurtOtotmasyonDataSet2.borclar);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtKalan.Text = kalan;
            txtOgrId.Text = id;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {

            // Ödenen borcu kalandan eksiltme
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(txtOdenen.Text);
            kalan = Convert.ToInt16(txtKalan.Text);
            yeniborc = kalan - odenen;
            txtKalan.Text = yeniborc.ToString();

            // Yeni kalan borcu veritabanına kaydetme
            SqlCommand komut = new SqlCommand("update borclar set ogrKalanBorc=@ogrKalanBorc where ogrId=@ogrId", bgl.baglanti());
            komut.Parameters.AddWithValue("@ogrId", txtOgrId.Text);
            komut.Parameters.AddWithValue("@ogrKalanBorc", txtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Borç Ödendi");
            this.borclarTableAdapter.Fill(this.yurtOtotmasyonDataSet2.borclar);
        }
    }
}
