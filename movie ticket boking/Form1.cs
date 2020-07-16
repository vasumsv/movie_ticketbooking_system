using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movie_ticket_boking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.SetVisibleCore(false);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string user = TextBox1.Text;
            String pass;
            pass = TextBox2.Text;
            if (user == "abhinaya" && pass == "123456789")
            {

                admin h = new admin();
                h.Show();
                this.SetVisibleCore(false);

            }
            else
            {
                MessageBox.Show("please enter a valid details");
            }
        }
    }
}
