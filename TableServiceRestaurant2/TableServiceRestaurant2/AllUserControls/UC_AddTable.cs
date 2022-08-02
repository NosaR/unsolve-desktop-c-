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

namespace TableServiceRestaurant2.AllUserControls
{
    public partial class UC_AddTable : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");
        Function fn = new Function();
        String query;
        public UC_AddTable()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            query = "Select * from Booking3";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_AddTable_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            timer1.Start();
        }

        protected int n;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            String TimerPicker = label8.Text;
            query = "Insert into Booking3 values ('" + guna2NumericUpDown1.Text + "', '" + guna2TextBox1.Text + "', '" + guna2ComboBox1.Text + "', '" + guna2TextBox3.Text + "', '" + guna2TextBox2.Text + "', '" + TimerPicker + "')";
            fn.setData(query);
            timer1.Start();
            clearAll();
            loadDataGrid();

            //n = guna2DataGridView1.Rows.Add();
            //guna2DataGridView1.Rows[n].Cells[0].Value = guna2NumericUpDown1.Value;
            //guna2DataGridView1.Rows[n].Cells[1].Value = guna2TextBox1.Text;
            //guna2DataGridView1.Rows[n].Cells[2].Value = guna2ComboBox1.Text;
            //guna2DataGridView1.Rows[n].Cells[3].Value = guna2TextBox3.Text;
            //guna2DataGridView1.Rows[n].Cells[4].Value = guna2Button2.Text;
        }

        public void clearAll()
        {
            guna2NumericUpDown1.Value = 0;
            guna2ComboBox1.SelectedIndex = -1;
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            int table = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String gender = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            int telp = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            String address = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            guna2NumericUpDown1.Value = table;
            guna2TextBox1.Text = name;
            guna2ComboBox1.Text = gender;
            guna2TextBox3.Text = telp.ToString();
            guna2TextBox2.Text = address;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString() +" "+ DateTime.Now.ToLongDateString();


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query = "Update Booking3 set TableID='" + guna2NumericUpDown1.Value + "', CustomerName='" + guna2TextBox1.Text + "', Gender='" + guna2ComboBox1.Text + "', Telephone='" + guna2TextBox3.Text + "', Address='" + guna2TextBox2.Text + "' where ID='" + id + "'";
            fn.UpdateData(query);
            loadDataGrid();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Menu where TableID like '"+guna2TextBox4.Text+"%'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            query = "Delete from Booking3 where ID='" + id + "'";
            fn.DeleteData(query);
            loadDataGrid();
        }
    }
}
