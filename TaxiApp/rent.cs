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
    public partial class rent : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lakshan\source\repos\TaxiApp\DB\TaxiDB.mdf;Integrated Security=True;Connect Timeout=30");


        public rent()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed) {
                    sqlcon.Open();

                    string sqlQuery = "Select * from Ve_Rent where v_type ='"+textBox1.Text+"' ";
                    SqlCommand cmd = new SqlCommand(sqlQuery,sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        mRent.Text = (dr["m_rent"].ToString());
                        wRent.Text = (dr["w_rent"].ToString());
                        dRent.Text = (dr["d_rent"].ToString());
                    }
                        
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                float total;
                if (checkBox1.Checked)
                {
                    total = ((float)Convert.ToDouble(noDay.Text) * ((float)Convert.ToDouble(dRate.Text))) +
                       ((float)Convert.ToDouble(mRent.Text) * ((float)Convert.ToDouble(months.Text))) +
                       ((float)Convert.ToDouble(wRent.Text) * ((float)Convert.ToDouble(weeks.Text))) +
                       ((float)Convert.ToDouble(dRent.Text) * ((float)Convert.ToDouble(days.Text)));
                }
                else
                {
                    total = ((float)Convert.ToDouble(mRent.Text) * ((float)Convert.ToDouble(months.Text))) +
                       ((float)Convert.ToDouble(wRent.Text) * ((float)Convert.ToDouble(weeks.Text))) +
                       ((float)Convert.ToDouble(dRent.Text) * ((float)Convert.ToDouble(days.Text)));
                }
                lbShow.Text = total.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
}
