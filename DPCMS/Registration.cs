using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPCMS
{
    public partial class Registration : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        public Registration()
        {
            InitializeComponent();
            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connect_open();
                Console.WriteLine("Connected to the database-registration.");

                string firstname = txtfirst.Text;
                string lastname = txtlast.Text;
                string username = txtusername.Text;
                string password = txtpass.Text;
                string email = txtmail.Text;
                string phone = txtnumber.Text;

                string sql = "INSERT INTO user_registration (firstname, lastname, username, pasword, email, phone) " +
                             "VALUES (@firstname, @lastname, @username, @pasword, @email, @phone)";

                using (SqlCommand cmd = new SqlCommand(sql, connection.con))
                {
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pasword", password);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful!");
                        Form1 login = new Form1();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed.");
                    }
                }

                connection.connect_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox.SelectedItem.ToString();

            if (selectedItem == "SignUp as DRIVER")
            {
                Registration_Driver driverForm = new Registration_Driver();
                driverForm.Show();
                this.Hide();
            }

        }
    }
}
