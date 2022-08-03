using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierRestaurant2.UserController
{
    public partial class UC_Transaksi : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True");
        String query, query2;
        Functions fn = new Functions();
        public UC_Transaksi()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            guna2DataGridView1.DataSource = null;
            txbIdPesanan.Clear();
            txbBayar.Clear();
            txbNamaPelanggan.Clear();
            txbTotalHarga.Clear();
        }

        public void LoadDataGrid()
        {
            query = "Select Namamenu, Harga, Jumlah from pesanan, menu where pesanan.Idmenu = menu.Idmenu and Idpesanan='" + txbIdPesanan.Text + "'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UC_Transaksi_Load(object sender, EventArgs e)
        {
            txbTotalHarga.Enabled = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txbBayar.Text == "" || txbIdPesanan.Text == "" || txbNamaPelanggan.Text == "" || txbTotalHarga.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh Kosong");
            }
                 
            else
            {
                query = "Insert into transaksi values('" + txbIdPesanan.Text + "', '" + txbTotalHarga.Text + "', '" + txbBayar.Text + "')";
                fn.SetData(query);
                ClearData();
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            Int64 total = Int64.Parse(txbTotalHarga.Text);
            Int64 bayar = Int64.Parse(txbBayar.Text);
            label8.Text = "Rp. " + (bayar - total).ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            query = "Select sum (TotalHarga) from pesanan";
            DataSet ds = fn.GetData(query);

            txbTotalHarga.Text = ds.Tables[0].Rows[0][0].ToString();

            query2 = "Select distinct (Namapelanggan) from pesanan, pelanggan where pesanan.Idpelanggan = pelanggan.Idpelanggan and Idpesanan='" + txbIdPesanan.Text+"'";
            DataSet ds2 = fn.GetData(query2);

            txbNamaPelanggan.Text = ds2.Tables[0].Rows[0][0].ToString();

        }
    }
}
