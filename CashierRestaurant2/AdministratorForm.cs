using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierRestaurant2
{
    public partial class AdministratorForm : Form
    {
        public AdministratorForm()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            uC_EntriMeja1.Visible = true;
            uC_Menu1.Visible = false;
            uC_EntriMeja1.BringToFront();
        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            uC_Menu1.Visible = false;
            uC_EntriMeja1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            uC_Menu1.Visible = true;
            uC_EntriMeja1.Visible = false;
            uC_Menu1.BringToFront();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
