using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableServiceRestaurant2
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");

        public LoginForm()
        {
            InitializeComponent();
        }

        public void resetData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh Kosong");
            }

            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * from User1 where UserID = '"+textBox1.Text+"' and UserName = '"+textBox2.Text+"'", conn);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }

            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetData();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
    }
