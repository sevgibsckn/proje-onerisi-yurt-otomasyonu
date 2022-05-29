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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        public string id,elektrik, su, dogalgaz, gida, internet, personel, diger;

        SqlBaglantim bgl=new SqlBaglantim();

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            TxtGiderID.Text= id;
            TxtElektrik.Text= elektrik;
            TxtSu.Text= su;
            TxtDogalgaz.Text= dogalgaz;
            TxtInternet.Text= internet;
            TxtGida.Text= gida;
            TxtPersonel.Text= personel;
            TxtDiger.Text= diger;
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Gider set Elektrik=@p1, Su=@p2, Dogalgaz=@p3,Internet=@p4,Gıda=@p4,Personel=@p5,Diger=@p6 where OdemeId=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p8", TxtGiderID.Text);
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Başarılı.");
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Başarısız.Yeniden Deneyiniz.");

            }


        }
    }
}
