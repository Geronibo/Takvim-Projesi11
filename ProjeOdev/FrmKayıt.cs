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
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELBER\\SQLEXPRESS;Initial Catalog=Takvim;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_UserData(Ad,Soyad,Tc,Telefon,Sifre,Email,KullanıcıTipi,Adres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglan);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTc.Text);
            komut.Parameters.AddWithValue("@p4", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtSıfre.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbKullanıcıType.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kaydiniz basariyla gercekleşmiştir..Sisteme tc ve sifrenizle kayit olabilirsiniz!");
        }
    }
}
