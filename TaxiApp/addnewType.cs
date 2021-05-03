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
    public partial class addnewType : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lakshan\source\repos\TaxiApp\DB\TaxiDB.mdf;Integrated Security=True;Connect Timeout=30");

        public addnewType()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("vehicle_Rent", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Vid", 0);
                   
                    
                    cmd.Parameters.AddWithValue("@v_type", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@m_rent", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@w_rent", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@d_rent", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@perkm", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@extra", textBox6.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Successfull");


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlcon.Close();
            }

            comboBox1.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void rent_Load(object sender, EventArgs e)
        {
            //combo box items
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            MessageBox.Show("Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
