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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {

            // Bölümleri Listeleme

            SqlCommand komut = new SqlCommand("Select bolumAd From bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            // Boş Odaları Listeleme

            SqlCommand komut2 = new SqlCommand("Select odaNo From odalar where odaKapasite != odaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtOgrAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            // Öğrenci Bilgilerinin Kayıt Edilme Komutları
            try
            {
    
                SqlCommand kaydet = new SqlCommand("insert into ogrenci (ogrAd, ogrSoyad, ogrTC, ogrTelefon, ogrDogum, ogrBolum, ogrMail, ogrOdaNo, ogrVeliAdSoyad, ogrVeliTelefon, ogrVeliAdres) values(@ogrAd, @ogrSoyad, @ogrTC, @ogrTelefon, @ogrDogum, @ogrBolum, @ogrMail, @ogrOdaNo, @ogrVeliAdSoyad, @ogrVeliTelefon, @ogrVeliAdres)", bgl.baglanti());
                kaydet.Parameters.AddWithValue("@ogrAd", txtOgrAd.Text);
                kaydet.Parameters.AddWithValue("@ogrSoyad", txtOgrSoyad.Text);
                kaydet.Parameters.AddWithValue("@ogrTC", mskTC.Text);
                kaydet.Parameters.AddWithValue("@ogrTelefon", mskOgrTelefon.Text);
                kaydet.Parameters.AddWithValue("@ogrDogum", mskDogum.Text);
                kaydet.Parameters.AddWithValue("@ogrBolum", cbBolum.Text);
                kaydet.Parameters.AddWithValue("@ogrMail", txtMail.Text);
                kaydet.Parameters.AddWithValue("@ogrOdaNo", cbOdaNo.Text);
                kaydet.Parameters.AddWithValue("@ogrVeliAdSoyad", txtVeliAdSoyad.Text);
                kaydet.Parameters.AddWithValue("@ogrVeliTelefon", mskVeliTelefon.Text);
                kaydet.Parameters.AddWithValue("@ogrVeliAdres", rchAdres.Text);
                kaydet.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi");

                // Öğrenci id'yi label'a çekme
                SqlCommand komut = new SqlCommand("select ogrId from ogrenci", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();

                // Öğrenci Borç Oluşturma
                SqlCommand kaydet2 = new SqlCommand("insert into borclar (ogrId, ogrAd, ogrSoyad) values (@ogrID, @ogrAd, @ogrSoyad)",bgl.baglanti());
                kaydet2.Parameters.AddWithValue("@ogrId", label12.Text);
                kaydet2.Parameters.AddWithValue("@ogrAd", txtOgrAd.Text);
                kaydet2.Parameters.AddWithValue("@ogrSoyad", txtOgrSoyad.Text);
                kaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Yeniden Deneyin");
            }

            // Oda Kontenjanı Azaltma
            SqlCommand komutOda = new SqlCommand("update odalar set odaAktif=odaAktif+1 where odaNo=@odaNo", bgl.baglanti());
            komutOda.Parameters.AddWithValue("@odaNo", cbOdaNo.Text);
            komutOda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        

    }
}
// Data Source=SELIM\SQLEXPRESS;Initial Catalog=yurtOtotmasyon;Integrated Security=True