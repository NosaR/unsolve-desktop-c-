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

namespace TableServiceRestaurant2
{
    public partial class LoginForm2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");
        public LoginForm2()
        {
            InitializeComponent();
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
                SqlDataAdapter sda = new SqlDataAdapter("Select * from User1 where UserID = '" + guna2TextBox1.Text + "' and UserName = '" + guna2TextBox2.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["UserName"].ToString() == "admin")
                        {
                            this.Hide();
                            AdminDashboard ad = new AdminDashboard();
                            ad.Show();
                        }

                        else if (dr["UserName"].ToString() == "cashier")
                        {
                            this.Hide();
                            CashierDashboard cd = new CashierDashboard();
                            cd.Show();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Username dan Nama Tidak Tesedia. Tolong Hubungi Admin");
                }
            }
            conn.Close();
        }

        private void LoginForm2_Load(object sender, EventArgs e)
        {

        }
    }
}

