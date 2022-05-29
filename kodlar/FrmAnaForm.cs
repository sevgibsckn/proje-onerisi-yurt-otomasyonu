using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonuDataSet1.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.yurtOtomasyonuDataSet1.Ogrenci);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text= DateTime.Now.ToLongDateString();
            label2.Text=DateTime.Now.ToLongTimeString();
        }


        //hesap makinesi
        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        //paint
        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.exe");
        }


        //radyolar
        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://fistikfm.canliyayinda.com:8016/";
        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://95.211.162.32:8016";
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://46.20.3.231:80 ";
        }




        //Formlar Arası Geçişler 

        private void ögrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayit fr=new FrmOgrKayit();
            fr.Show();
        }

        private void öğrenciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr=new FrmOgrListe();
            fr.Show();
            
        }




        //datagridden çekmeyeceği için öğrenci listeledikten sonra düzenlemek daha mantıklı !!!!

        private void öğrenciSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr = new FrmOgrListe();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider fr = new FrmGider();
            fr.Show();
        }

        private void giderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr=new FrmGiderListesi();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirIstatistik fr = new FrmGelirIstatistik();
            fr.Show();
        }

        private void şifreDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiPaneli fr = new FrmYoneticiPaneli();
            fr.Show();
        }

        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle fr = new FrmNotEkle();
            fr.Show();

        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu otomasyon Sevgi Başçeken tarafından hazırlanmıştır.", "Öğrenci Yurdu Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
