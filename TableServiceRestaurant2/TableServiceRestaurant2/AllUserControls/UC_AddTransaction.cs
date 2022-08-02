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
using DGVPrinterHelper;

namespace TableServiceRestaurant2.AllUserControls
{
    public partial class UC_AddTransaction : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");
        Function fn = new Function();
        SqlCommand cmd;
        SqlDataReader dr;
        String query;

        public UC_AddTransaction()
        {
            InitializeComponent();
        }

        private void LoadComboBox()
        {
            cbTable.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select TableID from Booking3";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cbTable.Items.Add(dr["TableID"].ToString());
            }
            conn.Close();
        }

        public void ShowListBox()
        {
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Menu";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["MenuName"]);
            }
            conn.Close();

            //query = "Select * from Menu";
            //DataSet ds = fn.GetData(query);
            //listBox1.DataSource = ds.Tables[0].Rows[1];
        }

        public void loadDataGrid()
        {
            query = "Select * from Booking3";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2NumericUpDown1.ResetText();
            txbTotal.Clear();

            String ItemName = listBox1.GetItemText(listBox1.SelectedItem);
            txbItemName.Text = ItemName;
            query = "Select Price,MenuID from Menu where MenuName='"+ItemName+"'";
            DataSet ds = fn.GetData(query);

            try
            {
                txbPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                txbMenuID.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch {}
        }

        private void UC_AddTransaction_Load(object sender, EventArgs e)
        {
            query = "Select MenuName from Menu";
            DataSet ds = fn.GetData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            LoadComboBox();
            //loadDataGrid();
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query = "Select MenuName from Menu where MenuName like '"+guna2TextBox1.Text+"%'";
            DataSet ds = fn.GetData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            //loadDataGrid();
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Int64 quantity = Int64.Parse(guna2NumericUpDown1.Value.ToString());
            Int64 price = Int64.Parse(txbPrice.Text);
            txbTotal.Text = (quantity * price).ToString();
        }

        protected int n, total = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
            }

            catch { };
            total -= int.Parse(guna2DataGridView1.Rows[0].Cells[5].Value.ToString());
            label7.Text = "Rp. " + total;
        }

        int id;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Struk Pembayaran";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount : " + label7.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            //id = int.Parse(guna2DataGridView1.Rows[0].Cells[0].Value.ToString());
            //int MenuID = int.Parse(guna2DataGridView1.Rows[0].Cells[1].Value.ToString());
            //String MenuName = guna2DataGridView1.Rows[0].Cells[2].Value.ToString();
            //int Quantity = int.Parse(guna2DataGridView1.Rows[0].Cells[3].Value.ToString());
            //int Price = int.Parse(guna2DataGridView1.Rows[0].Cells[4].Value.ToString());
            //int Total = int.Parse(guna2DataGridView1.Rows[0].Cells[5].Value.ToString());

            //query = "Insert into Order2 values (MenuID='" + MenuID + "', MenuName='"+MenuName+ "', Quantity='"+ Quantity + "', Price='"+Price+"', Total='"+Total+"')";
            //fn.setData(query);

            for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
            {
                SqlCommand cmd = new SqlCommand(@"Insert into Order4 values ('" + guna2DataGridView1.Rows[i].Cells[0].Value +"', '"+ guna2DataGridView1.Rows[i].Cells[1].Value + "', '"+ guna2DataGridView1.Rows[i].Cells[2].Value + "', '"+ guna2DataGridView1.Rows[i].Cells[3].Value + "', '"+ guna2DataGridView1.Rows[i].Cells[4].Value + "', '"+ guna2DataGridView1.Rows[i].Cells[5].Value + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            total = 0;
            guna2DataGridView1.Rows.Clear();
            label7.Text = "Rp. " + total;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txbTotal.Text != "0" && txbTotal.Text != "")
            {
                //loadDataGrid();
                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = cbTable.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = txbMenuID.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = txbItemName.Text;
                guna2DataGridView1.Rows[n].Cells[3].Value = guna2NumericUpDown1.Value;
                guna2DataGridView1.Rows[n].Cells[4].Value = txbPrice.Text;
                guna2DataGridView1.Rows[n].Cells[5].Value = txbTotal.Text;

                total += int.Parse(txbTotal.Text);
                label7.Text = "Rp. " + total;
            }

            else
            {
                MessageBox.Show("Quantity Harus 1", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
