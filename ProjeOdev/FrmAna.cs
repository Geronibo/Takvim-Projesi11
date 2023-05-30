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

namespace ProjeOdev
{
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELBER\\SQLEXPRESS;Initial Catalog=Takvim;Integrated Security=True");
        private void FrmAna_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Detay (OlayınTipi,Olayınaciklamasi,RandevuSaati,RandevuTarihi) values (@p1,@p2,@p3,@p4)",baglan);
            komut.Parameters.AddWithValue("@p1", rchTip.Text);
            komut.Parameters.AddWithValue("@p2", rchAciklama.Text);
            komut.Parameters.AddWithValue("@p3", txtSaat.Text);
            komut.Parameters.AddWithValue("@p4", dateTimePicker1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("randevunuz takvime basariyl eklenmistir...");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Detay", baglan);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            baglan.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update Tbl_Detay set OlayınTipi=@p1,OlayınAciklamasi=@p2,RandevuSaati=@p3,RandevuTarihi=@p4 where Id=@p5", baglan);
            guncelle.Parameters.AddWithValue("@p1", rchTip.Text);
            guncelle.Parameters.AddWithValue("@p2", rchAciklama.Text);
            guncelle.Parameters.AddWithValue("@p3", txtSaat.Text);
            guncelle.Parameters.AddWithValue("@p4", dateTimePicker1.Text);
            guncelle.Parameters.AddWithValue("@p5", label6.Text);
            guncelle.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Secilen randevu güncellenmistir..");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Detay where Id=@p1", baglan);
            komut.Parameters.AddWithValue("@p1", label6.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Secilen Randevu Silinmistir..");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {//datagired 'den veri çekme olayı 
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            rchTip.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            rchAciklama.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSaat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
