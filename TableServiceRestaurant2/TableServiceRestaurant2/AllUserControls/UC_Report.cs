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
    public partial class UC_Report : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2J93AI\SQLEXPRESS; Initial Catalog=db_restaurant_2; Integrated Security=True");
        Function fn = new Function();
        String query;
        public UC_Report()
        {
            InitializeComponent();
        }

        public void loadDataGrid()
        {
            query = "Select * from Order4 inner join Booking3 on Order4.TableID = Booking3.TableID";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_Report_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(guna2DateTimePicker1.Text);
            DateTime EndDate = DateTime.Parse(guna2DateTimePicker2.Text);

            query = "Select * from Order4 inner join Booking3 on Order4.TableID = Booking3.TableID where Date between '"+guna2DateTimePicker1.Text+"' and '"+guna2DateTimePicker2.Text+"' order by Date desc";
            fn.setData(query);
        }
    }
}
