using DGVPrinterHelper;
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
    public partial class UC_Laporan : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True");
        String query;
        Functions fn = new Functions();

        public UC_Laporan()
        {
            InitializeComponent();
        }

        public void LoadDataGrid()
        {
            query = "Select * from transaksi order by Idtransaksi";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_Laporan_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            timer1.Start();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Laporan Penjualan";
            timer1.Stop();
            String TimePicker = label1.Text;
            printer.SubTitle = TimePicker;
            timer1.Start();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(guna2DataGridView1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
    }
}
