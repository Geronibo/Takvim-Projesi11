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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELBER\\SQLEXPRESS;Initial Catalog=Takvim;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_UserData where Tc=@a1 and Sifre=@a2 ",baglan);
            komut.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a2", txtSıfre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

            }
            else
            {
                MessageBox.Show("hatali sifre veya tc");
            }
            baglan.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayıt frm = new FrmKayıt();
            frm.Show();
        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            FrmAna frm = new FrmAna();
            frm.Show();
        }
    }
}
