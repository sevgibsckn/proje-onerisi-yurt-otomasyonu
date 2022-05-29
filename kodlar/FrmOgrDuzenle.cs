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

namespace YurtKayitSistemi
{
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id,ad,soyad,TC,OgrTel,dogum,bolum;

       

        public string mail, odano, veliadsoyad,velitel,adres;

        SqlBaglantim bgl=new SqlBaglantim();

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            TxtOgrID.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTC.Text = TC;
            MskOgrTel.Text = OgrTel;
            MskDogum.Text = dogum;
            ComboBolum.Text = bolum;
            TxtMail.Text= mail;
            ComboOdaNo.Text= odano;
            TxtVeliAdSoyad.Text= veliadsoyad;
            MskVeliTel.Text = velitel;
            RchAdres.Text = adres;

        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTel=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTel=@p11,OgrVeliAdres=@p12 where OgrId=@p1 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtOgrID.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MskTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTel.Text);
                komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                komut.Parameters.AddWithValue("@p7", ComboBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                komut.Parameters.AddWithValue("@p9", ComboOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", MskVeliTel.Text);
                komut.Parameters.AddWithValue("@p12", RchAdres.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Düzenleme Tamamlandı.");
                bgl.baglanti().Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Düzenleme Tamamlanamadı.Yeniden Deneyiniz.");
              
            }
            
        }
        //öğrenci silme

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand(" delete from Ogrenci where OgrId =@k1",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1",TxtOgrID.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silme Başarılı.");
            bgl.baglanti().Close();




            //öğrenci silindikten sonra oda kontenjanı arttırma


            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@b1",bgl.baglanti());
            komutoda.Parameters.AddWithValue("@b1", ComboOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();

        }



       

    }
}
