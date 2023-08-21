using DPCMS.Properties;
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

namespace DPCMS
{
    public partial class FeedBack : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        public FeedBack()
        {
            InitializeComponent();
            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
        }

        private void pb_star5_Click(object sender, EventArgs e)
        {
            pb_star1.Image = Resources.yellow_star;
            pb_star2.Image = Resources.yellow_star;
            pb_star3.Image = Resources.yellow_star;
            pb_star4.Image = Resources.yellow_star;
            pb_star5.Image = Resources.yellow_star;
        }

        private void pb_star4_Click(object sender, EventArgs e)
        {
            pb_star5.Image = Resources.white_star;
            pb_star1.Image = Resources.yellow_star;
            pb_star2.Image = Resources.yellow_star;
            pb_star3.Image = Resources.yellow_star;
            pb_star4.Image = Resources.yellow_star;
            
        }

        private void pb_star3_Click(object sender, EventArgs e)
        {
            pb_star4.Image = Resources.white_star;
            pb_star5.Image = Resources.white_star;
            pb_star1.Image = Resources.yellow_star;
            pb_star2.Image = Resources.yellow_star;
            pb_star3.Image = Resources.yellow_star;
            
        }

        private void pb_star2_Click(object sender, EventArgs e)
        {
            pb_star3.Image = Resources.white_star;
            pb_star4.Image = Resources.white_star;
            pb_star5.Image = Resources.white_star;
            pb_star1.Image = Resources.yellow_star;
            pb_star2.Image = Resources.yellow_star;
            
        }

        private void pb_star1_Click(object sender, EventArgs e)
        {
            pb_star2.Image = Resources.white_star;
            pb_star3.Image = Resources.white_star;
            pb_star4.Image = Resources.white_star;
            pb_star5.Image = Resources.white_star;
            pb_star1.Image = Resources.yellow_star;
            
        }

        private void txtcomment_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connect_open();
                Console.WriteLine("Connected to the database-Feedback.");
                string comment = txtcomment.Text;

                string sql = "INSERT INTO Feedbacks (Comment)" + "VALUES (@comment)";

                using (SqlCommand cmd = new SqlCommand(sql, connection.con))
                {
                    cmd.Parameters.AddWithValue("@comment", comment);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Feedback submitted successfully!");
                        txtcomment.Clear(); // Clear the comment TextBox
                    }
                    else
                    {
                        MessageBox.Show("Feedback submission failed.");
                    }
                }

                connection.connect_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
