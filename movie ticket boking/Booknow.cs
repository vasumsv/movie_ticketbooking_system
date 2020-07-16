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
    public partial class Booknow : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\movie.mdf;Integrated Security=True;Connect Timeout=30");
        public Booknow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.SetVisibleCore(false);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO booking (movie,name,number,seat,date,amount) VALUES ( '" + ComboBox1.Text.ToString().Trim().Replace("'", "''") + "','" + TextBox1.Text.ToString().Trim().Replace("'", "''") + "','" + TextBox2.Text.ToString().Trim().Replace("'", "''") + "','" + ComboBox2.Text.ToString().Trim().Replace("'", "''") + "','" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + TextBox6.Text.ToString().Trim().Replace("'", "''") + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seat Booked sucessfully");
                con.Close();
                //booktable();
                ComboBox1.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                ComboBox2.Text = "";
                TextBox6.Text = "";
        }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid details");
            }
}

        private void Button2_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            ComboBox2.Text = "";
            TextBox6.Text = "";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from movie where movie_name ='" + ComboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TextBox6.Text = dr["price"].ToString();
            }
            con.Close();
        }

        public void moviedetails()
        {
            ComboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select movie_name from movie";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ComboBox1.Items.Add(dr["movie_name"].ToString());
            }
            con.Close();
           
        }

        private void Booknow_Load(object sender, EventArgs e)
        {
            moviedetails();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox2.SelectedItem.ToString() == "Front Area")
            {
                TextBox6.Text = Convert.ToString((Decimal.Parse(TextBox6.Text) - 80));
            }
            else if (ComboBox2.SelectedItem.ToString() == "Back Area ")
            {
                TextBox6.Text = Convert.ToString((Decimal.Parse(TextBox6.Text) - 60));
            }
            else if (ComboBox2.SelectedItem.ToString() == "Corner ")
            {
                TextBox6.Text = Convert.ToString((Decimal.Parse(TextBox6.Text) - 30));
            }
        }
    }
}
