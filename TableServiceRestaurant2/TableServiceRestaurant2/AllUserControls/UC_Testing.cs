using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableServiceRestaurant2.AllUserControls
{
    public partial class UC_Testing : UserControl
    {
        public UC_Testing()
        {
            InitializeComponent();
        }

        private void UC_Testing_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        protected int n;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            n = guna2DataGridView1.Rows.Add();
            guna2DataGridView1.Rows[n].Cells[1].Value = textBox1.Text;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            for (int i = guna2DataGridView1.RowCount -1; i >= 0; i--)
            {
                //String name = guna2DataGridView1.Rows[0].Cells[0].Value.ToString();
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                //String name = row.Cells[0].Value.ToString();
                if (Convert.ToBoolean(row.Cells["SelectLeft"].Value))
                {
                    guna2DataGridView2.Rows.Add(row.Cells[1].Value.ToString());
                    guna2DataGridView1.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
