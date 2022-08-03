using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CashierRestaurant2
{
    class Functions
    {
       protected SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-OGQRBL1\RPL_123; Initial Catalog=db_restaurant_2; Integrated Security=True";
            return conn;
        }

        public DataSet GetData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public void SetData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Berhasil Disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DeleteData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Berhasil Dihapus.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void UpdateteData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Berhasil Diupdate.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
