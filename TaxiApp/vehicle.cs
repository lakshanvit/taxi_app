using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TaxiApp
{
    public partial class vehicle : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lakshan\source\repos\TaxiApp\DB\TaxiDB.mdf;Integrated Security=True;Connect Timeout=30");


        public vehicle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("addVehicle",sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vehicleId",0);
                    cmd.Parameters.AddWithValue("@vehicleNo", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@vehicleType", textBox2.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Successfull");


                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlcon.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
}
