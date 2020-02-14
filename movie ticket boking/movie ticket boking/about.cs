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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.SetVisibleCore(false);
        }
    }
}
