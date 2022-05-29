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
    public partial class FrmYoneticiPaneli : Form
    {
        public FrmYoneticiPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();

        private void FrmYoneticiPaneli_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet5.Admin' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);

        }
        


        //yönetici ekleme işlemi 

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre)values(@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Yönetici Ekleme İşlemi Gerçekleşti.");
            bgl.baglanti().Close();
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);

        }


        //datagriddeki bilgileri textboxa çekme

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id,ad, sifre;
            id=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtKullaniciAdi.Text = ad;
            TxtSifre.Text = sifre;
            TxtYoneticiID.Text = id;


        }


        //yönetici silme işlemi

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Admin where YoneticiId=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtYoneticiID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Yönetici Silme İşlemi Gerçekleşti.");
            bgl.baglanti().Close();
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);

        }

        //yönetici güncelleme işlemi

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Admin set YoneticiAd=@p1,YoneticiSifre=@p2 where YoneticiId=@p3 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            komut.Parameters.AddWithValue("@p3", TxtYoneticiID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
            bgl.baglanti().Close();
            this.adminTableAdapter.Fill(this.yurtOtomasyonuDataSet5.Admin);


        }
    }
}
