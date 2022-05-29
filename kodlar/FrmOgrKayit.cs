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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

          SqlBaglantim bgl = new SqlBaglantim();

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            FrmOgrKayit_Load(sender, e, bgl);
        }

        private void FrmOgrKayit_Load(object sender, EventArgs e, SqlBaglantim bgl)
        {
           

            SqlCommand komut = new SqlCommand("Select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ComboBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            //boş odaları listeleme komutları

            SqlCommand komut2=new SqlCommand("select odano from odalar where odakapasite!=odaaktif", bgl.baglanti());
            SqlDataReader oku2=komut2.ExecuteReader();
            while (oku2.Read())
            {
                ComboOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }


        //kaydet butonuyla öğrenci kayıt

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
              
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad,OgrTC,OgrTel,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTel,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                komutkaydet.Parameters.AddWithValue("@p4", MskOgrTel.Text);
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                komutkaydet.Parameters.AddWithValue("@p6", ComboBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", ComboOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTel.Text);
                komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                komutkaydet.ExecuteNonQuery();                
                MessageBox.Show("Kayıt Başarılı.");
                bgl.baglanti().Close();


                // öğrenci id yi label12ye çekme

                SqlCommand komut = new SqlCommand("select OgrId from Ogrenci",bgl.baglanti());
                SqlDataReader oku= komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();

                }
                bgl.baglanti().Close();




                //öğrenci borç alanı oluşturma

                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar(OgrId,OgrAd,OgrSoyad)values(@b1,@b2,@b3)",bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1",label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();



            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Başarısız.Lütfen Yeniden Deneyiniz.");            
            }



            //öğrenci oda kontenjanı arttırma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@k1",bgl.baglanti());
            komutoda.Parameters.AddWithValue("@k1", ComboOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();


        }
    }
}
//Data Source=LAPTOP-57HI71K3\SQLEXPRESS;Initial Catalog=yurtOtomasyonu;Integrated Security=True