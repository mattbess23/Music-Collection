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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            /*sql connection,sql adaptor,sql command*/

            /*MessageBox.Show(cb/Artist.SelectedValue.ToString());
            MessageBox.Show(cbogenre.SelectedValue.ToString());
            MessageBox.Show(cboRecord.SelectedValue.ToString());
            MessageBox.Show(cboyear.SelectedValue.ToString());*/

            string a = string.Format("INSERT INTO Album(Album_Name,ArtistID,GenreID,Year,Record_LabelID) VALUES('{0}','{1}','{2}','{3}','{4}')", txtalbum.Text, cbArtist.SelectedValue.ToString(), cbogenre.SelectedValue.ToString(), cboyear.SelectedValue.ToString(), cboRecord.SelectedValue.ToString());
            InsertSQL(a);

            string b = "SELECT * FROM Album";
            DataTable dt = GetSQL(b);
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

        private void InsertSQL(string a)
        {
            conn.ConnectionString = @"Server=BETA;Database=Music_Collection;User Id=sa;Password=cl3@r;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = a;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ArtistSQL = "SELECT ArtistID, Artist_Name FROM Artist";
            DataTable dt = GetSQL(ArtistSQL);
            cbArtist.DataSource = dt;
            cbArtist.DisplayMember = dt.Columns["Artist_Name"].ToString();
            cbArtist.ValueMember = dt.Columns["ArtistID"].ToString();

            string GenreSQL = "SELECT GenreID,Genre_Name FROM Genre";
            dt = GetSQL(GenreSQL);
            cbogenre.DataSource = dt;
            cbogenre.ValueMember = dt.Columns["GenreID"].ToString();
            cbogenre.DisplayMember = dt.Columns["Genre_Name"].ToString();

            string RecordSQL = "SELECT Record_LabelID,Record_Label_Name FROM Record_Label";
            dt = GetSQL(RecordSQL);
            cboRecord.DataSource = dt;
            cboRecord.ValueMember = dt.Columns["Record_LabelID"].ToString();
            cboRecord.DisplayMember = dt.Columns["Record_Label_Name"].ToString();

            DataTable dtYears = new DataTable();
            dtYears.Columns.Add("ID", typeof(int));
            dtYears.Columns.Add("Display", typeof(int));

            for (int year = DateTime.Now.Year; year >= 1955; year--)
            {
                dtYears.Rows.Add(year, year);

            }

            cboyear.DataSource = dtYears;
            cboyear.ValueMember = dtYears.Columns["ID"].ToString();
            cboyear.DisplayMember = dtYears.Columns["Display"].ToString();

            int l = 0;
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtalbum.Text = string.Empty;
        }
    }
}