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

namespace Music_Collection
{
    public partial class Artist : Form
    {
        public Artist()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        private DataTable GetSQL(string a)
        {
            conn.ConnectionString = @"Server=BETA;Database=Music_Collection;User Id=sa;Password=cl3@r;";

            SqlDataAdapter adap = new SqlDataAdapter(a, conn);

            DataTable dt = new DataTable();

            conn.Open();
            adap.Fill(dt);
            conn.Close();

            return dt;
        }
        private void Artist_Load(object sender, EventArgs e)
        {
            insertArtist();
        }
        private void insertArtist()
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string cmdString = "INSERT INTO Artist (Artist_Name) VALUES (@Artist_Name)";
            string ConnectionString = @"Server=BETA;Database=Music_Collection;User Id=sa;Password=cl3@r;";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@Artist_Name", txtInsertArt.Text);

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
