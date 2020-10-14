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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            (new Form1()).ShowDialog();

            populateGrid();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void Main_Load(object sender, EventArgs e)
        {
            populateGrid();
        }
        private void populateGrid()
        {
            string a = @"

                            Select alb.AlbumID,alb.Album_Name,alb.Year,art.Artist_Name,gen.Genre_Name,rec.Record_Label_Name
	                        from Album alb
		                    join Artist art 
			                ON alb.ArtistID = art.ArtistID 
		                    join Genre gen
			                ON alb.GenreID = gen.GenreID 
		                    join Record_Label rec
		                    ON alb.Record_LabelID = rec.Record_LabelID 
                            ORDER BY Album_Name 
                            ";
            DataTable dt = GetSQL(a);

            dataGridView1.DataSource = dt;
        }
        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            Artist a = new Artist();
            a.ShowDialog();
        }
    }
}
