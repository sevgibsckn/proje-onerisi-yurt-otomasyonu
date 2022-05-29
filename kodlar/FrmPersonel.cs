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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl=new SqlBaglantim();

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet6.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet6.Personel);

        }


        //personel kaydetme İşlemleri
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman ) values(@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtPerGorev.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Kaydetme İşlemi Başarılı.");
            bgl.baglanti().Close();
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet6.Personel);

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, gorev;
            id=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();


            TxtPerID.Text = id;
            TxtPerAd.Text=ad;
            TxtPerGorev.Text=gorev;

        }




        //personel silme işlemleri
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Personel where PersonelId=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtPerID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Silme İşlemi Başarılı");
            bgl.baglanti().Close();
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet6.Personel);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Personel set PersonelAdSoyad=@k1,PersonelDepartman=@k2 where PersonelId=@k3",bgl.baglanti());
            komut.Parameters.AddWithValue("@k1", TxtPerAd.Text);
            komut.Parameters.AddWithValue("@k2", TxtPerGorev.Text);
            komut.Parameters.AddWithValue("@k3", TxtPerID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Güncelleme İşlemi Başarılı.");
            bgl.baglanti().Close();
            this.personelTableAdapter.Fill(this.yurtOtomasyonuDataSet6.Personel);



        }
    }
}
