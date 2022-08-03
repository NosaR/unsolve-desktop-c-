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
    public partial class KasirForm : Form
    {
        public KasirForm()
        {
            InitializeComponent();
        }

        private void KasirForm_Load(object sender, EventArgs e)
        {
            uC_Transaksi1.Visible = false;
            uC_Laporan1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            uC_Transaksi1.Visible = true;
            uC_Transaksi1.BringToFront();
            uC_Laporan1.Visible = false;
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            uC_Laporan1.Visible = true;
            uC_Laporan1.BringToFront();
            uC_Transaksi1.Visible = false;
        }
    }
}
