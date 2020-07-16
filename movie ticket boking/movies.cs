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
    public partial class movies : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\movie.mdf;Integrated Security=True;Connect Timeout=30");
        public movies()
        {
            InitializeComponent();
            topmovietable();
            upcommingmovies();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.SetVisibleCore(false);
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
                //dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }
            catch
            {
                MessageBox.Show("No Record Found");
            }
        }
        private void upcommingmovies()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select movie_name from upcommingmovies", con);
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

        private void movies_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
