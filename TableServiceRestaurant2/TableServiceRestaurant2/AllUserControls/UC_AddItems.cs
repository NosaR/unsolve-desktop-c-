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
    public partial class UC_AddItems : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");

        Function fn = new Function();
        String query;
        public UC_AddItems()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            query = "Select * from Menu";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_AddItems_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            var data = "Insert into Menu values ('" + guna2TextBox1.Text + "', '" + guna2TextBox2.Text + "', '" + guna2TextBox3.Text + "')";
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(data, conn);
            cmd.ExecuteReader();
            MessageBox.Show("Data Berhasil Disimpan");
            conn.Close();
            clearAll();
        }

        public void clearAll()
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Menu where MenuName like '" + guna2TextBox4.Text + "%'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            int menuid = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            guna2TextBox1.Text = menuid.ToString();
            guna2TextBox2.Text = name;
            guna2TextBox3.Text = price.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            query = "Delete from Menu where ID='" + id + "'";
            fn.DeleteData(query);
            loadDataGrid();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query = "Update Menu set MenuID='" + guna2TextBox1.Text + "', MenuName='" + guna2TextBox2.Text + "', Price='" + guna2TextBox3.Text + "' where ID='" + id + "'";
            fn.UpdateData(query);
            loadDataGrid();
        }
    }
}
