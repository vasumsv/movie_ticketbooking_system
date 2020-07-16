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

namespace movie_ticket_boking
{
    public partial class home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\movie.mdf;Integrated Security=True;Connect Timeout=30");
        public home()
        {
            InitializeComponent();
            bookingtable();
            topmovietable();
        }

        private void booknowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booknow b = new Booknow();
            b.Show();
            this.SetVisibleCore(false);
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movies b = new movies();
            b.Show();
            this.SetVisibleCore(false);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form1 b = new Form1();
            b.Show();
            this.SetVisibleCore(false);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           about b = new about();
            b.Show();
            this.SetVisibleCore(false);
        }
        private void bookingtable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select movie,name,seat,amount from booking", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }
            catch
            {
                MessageBox.Show("No Record Found");
            }
        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void topmovietable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select movie_name from movie", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView2.DataSource = ds.Tables["ss"];
                con.Close();

            }
            catch
            {
                MessageBox.Show("No Record Found");
            }
        }
    }
}
