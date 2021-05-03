using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addnewType r = new addnewType();
            this.Hide();
            r.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vehicle v = new vehicle();
            this.Hide();
            v.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rent b = new rent();
            this.Hide();
            b.Show();

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            hire h = new hire();
            this.Hide();
            h.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
