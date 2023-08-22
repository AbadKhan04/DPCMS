using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPCMS
{
    public partial class User : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        public User()
        {
            InitializeComponent();
        }

        private void btnride_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connect_open();
                Console.WriteLine("Connected to the database-user.");

                string pickup = txtpick.Text;
                string destination = txtdestination.Text;
                string fare = txtfare.Text;
                string ridetype = comboBox1.SelectedItem.ToString();

                string sql = "INSERT INTO booking (pickup, destination, fare, ridetype) " +
                             "VALUES (@pickup, @destination, @fare, @ridetype)";

                using (SqlCommand cmd = new SqlCommand(sql, connection.con))
                {
                    cmd.Parameters.AddWithValue("@pickup", pickup);
                    cmd.Parameters.AddWithValue("@destination", destination);
                    cmd.Parameters.AddWithValue("@fare", fare);
                    cmd.Parameters.AddWithValue("@ridetype", ridetype);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ride Book successful!");
                        map map = new map();
                        map.Show();
                    }
                    else
                    {
                        MessageBox.Show("Booking failed.");
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
