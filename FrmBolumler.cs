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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtotmasyonDataSet.bolumler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bolumlerTableAdapter.Fill(this.yurtOtotmasyonDataSet.bolumler);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("delete from bolumler where bolumId=@bolumId", bgl.baglanti());
                komut2.Parameters.AddWithValue("@bolumId", txtBolumId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtotmasyonDataSet.bolumler); // bölüm eklendiğinde direkt datagridde görebiliriz. Yani refresh gibi. Programı tekrardan başlatmadan refresh olur.
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu Yeniden Deneyin");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into bolumler (bolumAd) values (@bolumAd)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@bolumAd", txtBolumAd.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
                this.bolumlerTableAdapter.Fill(this.yurtOtotmasyonDataSet.bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu Yeniden Deneyin");
            }
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumAd;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            txtBolumId.Text = id;
            txtBolumAd.Text = bolumAd;

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut3 = new SqlCommand("update bolumler set bolumAd=@bolumAd where bolumId=@bolumId", bgl.baglanti());
                komut3.Parameters.AddWithValue("@bolumId", txtBolumId.Text);
                komut3.Parameters.AddWithValue("@bolumAd", txtBolumAd.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtotmasyonDataSet.bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu Yeniden Deneyin");
            }
        }
    }
}
