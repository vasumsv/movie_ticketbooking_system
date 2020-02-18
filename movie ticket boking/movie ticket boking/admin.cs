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
    public partial class admin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\movie.mdf;Integrated Security=True;Connect Timeout=30");
        public admin()
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO movie (movie_name,price) VALUES ( '" + TextBox1.Text.ToString().Trim().Replace("'", "''") + "','" + TextBox2.Text.ToString().Trim().Replace("'", "''") + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Movie Added");
                con.Close();
                topmovietable();
                TextBox1.Text = "";
                TextBox2.Text = "";

        }
            catch (Exception)
            {
                MessageBox.Show("please check again");
            }
}

        private void topmovietable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from movie", con);
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
        private void upcommingmovies()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from upcommingmovies", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM movie WHERE movie_name='" + TextBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed movie  sucessfully");
                con.Close();
                topmovietable();
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("try again");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO upcommingmovies (movie_name,date) VALUES ( '" + textBox3.Text.ToString().Trim().Replace("'", "''") + "','" +DateTimePicker1.Value.ToString("yyyy-MM-dd")   + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Movie Added");
                con.Close();
                upcommingmovies();
                textBox3.Text = "";
              

            }
            catch (Exception)
            {
                MessageBox.Show("please check again");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
         
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
         //       DateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM upcommingmovies WHERE movie_name='" + textBox3.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed movie  sucessfully");
                con.Close();
              
                textBox3.Text = "";
                upcommingmovies();
            }
            catch (Exception)
            {
                MessageBox.Show("try again");
            }
        }
    }
}
