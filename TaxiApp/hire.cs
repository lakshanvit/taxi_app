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
    public partial class hire : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lakshan\source\repos\TaxiApp\DB\TaxiDB.mdf;Integrated Security=True;Connect Timeout=30");

        public hire()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();

                    string sqlQuery = "Select * from Ve_Rent where v_type ='" + textBox1.Text + "' ";
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        pkm.Text = (dr["perkm"].ToString());
                        ekm.Text = (dr["extra"].ToString());
                        
                    }

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                float total = ((float)Convert.ToDouble(pz.Text) * ((float)Convert.ToDouble(pkm.Text))) +
                       ((float)Convert.ToDouble(exkm.Text) * ((float)Convert.ToDouble(ekm.Text)));

                lbShow.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message");
            }

            textBox1.Clear();
            pkm.Clear();
            ekm.Clear();
            comboBox1.ResetText();
            pz.Clear();
            exkm.Clear();
            tr.Clear();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                float extra = (float)Convert.ToDouble(tr.Text) - (float)Convert.ToDouble(pz.Text);
                exkm.Text = extra.ToString();
            }
            catch (Exception exc)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
