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

namespace CashierRestaurant2
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh Kosong");
            }

            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * from user2 where Iduser = '"+guna2TextBox1.Text+"' and Namauser = '" + guna2TextBox2.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Namauser"].ToString() == "admin")
                        {
                            this.Hide();
                            AdministratorForm adm = new AdministratorForm();
                            adm.Show();
                        }

                        else if (dr["Namauser"].ToString() == "kasir")
                        {
                            this.Hide();
                            KasirForm kf = new KasirForm();
                            kf.Show();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Id User dan Nama User Tidak Tersedia. Mohon Hubungi Admin");
                }
            }
            conn.Close();
        }
    }
}
