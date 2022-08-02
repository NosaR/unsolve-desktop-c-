using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableServiceRestaurant2
{
    public partial class CashierDashboard : Form
    {
        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LoginForm2 lf = new LoginForm2();
            lf.Show();
            this.Hide();
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            uC_AddTransaction1.Visible = false;
            uC_Report1.Visible = false;
        }

        private void CashierDashboard_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_AddTransaction1.Visible = true;
            uC_Report1.Visible = false;
            uC_AddTransaction1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            uC_AddTransaction1.Visible = false;
            uC_Report1.Visible = true;
            uC_Report1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
