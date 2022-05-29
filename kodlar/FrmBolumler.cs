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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        
        SqlBaglantim bgl=new SqlBaglantim();

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet.Bolumler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);

        }

        //bölümler formunda bölüm ekleme

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {


                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut1.ExecuteNonQuery();
              
                MessageBox.Show("Bölüm Ekleme Başarılı.");
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("Bölüm Ekleme Başarısız.Yeniden Deneyiniz.");
            }
        }

        //bölümler formunda bölüm silme

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where BolumId=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumID.Text);
                komut2.ExecuteNonQuery();
               
                MessageBox.Show("Silme İşlemi Başarılı.");
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Silme İşlemi Başarısız.Yeniden Deneyiniz.");

            }
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad=dataGridView1.Rows[secilen].Cells[1].Value.ToString();    

            TxtBolumID.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        //bölümler formunda bölüm güncelleme

        private void PcbBolumGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
           
                SqlCommand komut3 = new SqlCommand("update Bolumler set BolumAd=@p1 where BolumId=@p2",bgl.baglanti());
                komut3.Parameters.AddWithValue("@p2",TxtBolumID.Text);
                komut3.Parameters.AddWithValue("@p1",TxtBolumAd.Text);
                komut3.ExecuteNonQuery();
               
                MessageBox.Show("Güncelleme Başarılı.");
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);


            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Başarısız.Lütfen Yeniden Deneyiniz.");
                
            }
        }
    }
}
