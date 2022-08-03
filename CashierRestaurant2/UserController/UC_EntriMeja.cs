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
    public partial class UC_EntriMeja : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True");
        String query;
        Functions fn = new Functions();

        public UC_EntriMeja()
        {
            InitializeComponent();
        }

        public void LoadDataGrid()
        {
            query = "Select * from meja order by Idmeja asc";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_EntriMeja_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "Insert into meja (Namameja) values ('" + guna2TextBox2.Text + "')";
            fn.SetData(query);
            LoadDataGrid();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query = "Update meja set Namameja='"+guna2TextBox2.Text+"' where Idmeja='"+id+"'";
            fn.UpdateteData(query);
            LoadDataGrid();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String NamaMeja = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            guna2TextBox2.Text = NamaMeja;
        }

        int id;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            query = "Delete from meja where Idmeja='" + id + "'";
            fn.DeleteData(query);
            LoadDataGrid();
        }
    }
}
