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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        public string id, ad, soyad, TC, telefon, dogum, bolum;

        

        private void cbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bölümleri Listeleme

            SqlCommand komut = new SqlCommand("Select bolumAd From bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void cbOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Odalari Listeleme
            SqlCommand komut5 = new SqlCommand("Select odaNo From odalar where odaKapasite != odaAktif", bgl.baglanti());
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                cbOdaNo.Items.Add(oku5[0].ToString());
            }
            bgl.baglanti().Close(); 
        }

        

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand komut = new SqlCommand("update ogrenci set ogrAd=@ogrAd, ogrSoyad=@ogrSoyad, ogrTC=@ogrTC, ogrTelefon=@ogrTelefon, ogrDogum=@ogrDogum, ogrBolum=@ogrBolum, ogrMail=@ogrMail, ogrOdaNo=@ogrOdaNo, ogrVeliAdSoyad=@ogrVeliAdSoyad, ogrVeliTelefon=@ogrVeliTelefon, ogrVeliAdres=@ogrVeliAdres where ogrId=@ogrId", bgl.baglanti());
                komut.Parameters.AddWithValue("@ogrId", txtOgrId.Text);
                komut.Parameters.AddWithValue("@ogrAd", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@ogrSoyad", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@ogrTC", mskTC.Text);
                komut.Parameters.AddWithValue("@ogrTelefon", mskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@ogrDogum", mskDogum.Text);
                komut.Parameters.AddWithValue("@ogrBolum", cbBolum.Text);
                komut.Parameters.AddWithValue("@ogrMail", txtMail.Text);
                komut.Parameters.AddWithValue("@ogrOdaNo", cbOdaNo.Text);
                komut.Parameters.AddWithValue("@ogrVeliAdSoyad", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@ogrVeliTelefon", mskVeliTelefon.Text);
                komut.Parameters.AddWithValue("@ogrVeliAdres", rchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Yeniden Deneyin");
            }
        }

        public string mail, odano, veliad, velitel, adres;

        

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtOgrId.Text = id;
            txtOgrAd.Text = ad;
            txtOgrSoyad.Text = soyad;
            mskTC.Text = TC;
            mskOgrTelefon.Text = telefon;
            mskDogum.Text = dogum;
            cbBolum.Text = bolum;
            txtMail.Text = mail;
            cbOdaNo.Text = odano;
            txtVeliAdSoyad.Text = veliad;
            mskVeliTelefon.Text = velitel;
            rchAdres.Text = adres;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            // Öğrenci silme
            SqlCommand komutSil = new SqlCommand("delete from ogrenci where ogrId=@ogrid",bgl.baglanti());
            komutSil.Parameters.AddWithValue("@ogrid", txtOgrId.Text);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");

            // Aktifliği Azaltma
            SqlCommand komutoda = new SqlCommand("update odalar set odaAktif=odaAktif-1 where odaNo=@odaNo", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@odaNo", cbOdaNo.Text);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();            
        }
    }
}
