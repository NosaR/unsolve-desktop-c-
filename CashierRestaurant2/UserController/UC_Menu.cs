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
    public partial class UC_Menu : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True");
        String query;
        Functions fn = new Functions();
        public UC_Menu()
        {
            InitializeComponent();
        }

        public void LoadDataGrid()
        {
            query = "Select * from menu order by Namamenu asc";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "Insert into menu (Namamenu, Harga) values ('" + guna2TextBox2.Text + "', '"+guna2TextBox1.Text+"')";
            fn.SetData(query);
            LoadDataGrid();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query = "Update menu set Namamenu='" + guna2TextBox2.Text + "', Harga='"+guna2TextBox1.Text+"' where Idmenu='" + id + "'";
            fn.UpdateteData(query);
            LoadDataGrid();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String NamaMenu = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int harga= int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            guna2TextBox1.Text = NamaMenu;
            guna2TextBox2.Text = harga.ToString();
        }

        int id;

        private void UC_Menu_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            query = "Delete from menu where Idmenu='" + id + "'";
            fn.DeleteData(query);
            LoadDataGrid();
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String NamaMenu = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int harga = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            guna2TextBox2.Text = NamaMenu;
            guna2TextBox1.Text = harga.ToString();
        }
    }
}
