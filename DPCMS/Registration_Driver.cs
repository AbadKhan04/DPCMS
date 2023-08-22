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
    public partial class Registration_Driver : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();

        //APPLYING Strategy PATTERN (behavioral pattern) to handle multiple authentication methods (Driver , Admin)  *
        private IRegistrationStrategy registrationStrategy;
        public Registration_Driver()
        {
            InitializeComponent();
            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

            //Set Driver to default 
            registrationStrategy = new DriverRegistrationStrategy(connection);  //*

        }


        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connect_open();
                Console.WriteLine("Connected to the database-registration_Driver.");

                string firstname = txtFirst.Text;
                string lastname = txtLast.Text;
                string email = txtEmail.Text;
                string password = txtPass.Text;
                string CNIC = txtCNIC.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string license = txtlicense.Text;
                //string designation = comboBox1.SelectedItem.ToString();

                registrationStrategy.Register(firstname, lastname, email, password, CNIC, phone, address, license); //*
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

            if (selectedItem == "SignUp as USER")
            {
                Registration UserForm = new Registration();
                UserForm.Show();
                this.Close();
            }
        }
        public interface IRegistrationStrategy      
        {
            void Register(string firstname, string lastname, string email, string password,
                          string CNIC, string phone, string address, string license);
        }

        public class DriverRegistrationStrategy : IRegistrationStrategy
        {
            private DPCMS_CONNECTION _connection;

            public DriverRegistrationStrategy(DPCMS_CONNECTION connection)
            {
                _connection = connection;
            }

            public void Register(string firstname, string lastname, string email, string password,
                                 string CNIC, string phone, string address, string license)
            {
                try
                {
                    string sql = "INSERT INTO staff_registration (firstname, lastname, email, pasword, CNIC, phone, addres, license, designation) " +
                             "VALUES (@firstname, @lastname, @email, @pasword, @CNIC, @phone, @addres, @license, @designation)";

                    using (SqlCommand cmd = new SqlCommand(sql, _connection.con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pasword", password);
                        cmd.Parameters.AddWithValue("@CNIC", CNIC);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addres", address);
                        cmd.Parameters.AddWithValue("@license", license);
                        cmd.Parameters.AddWithValue("@designation", "Driver");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Driver Registration successful!");
                            Form1 login = new Form1();
                            login.Show();
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public class AdminRegistrationStrategy : IRegistrationStrategy
        {
            private DPCMS_CONNECTION _connection;

            public AdminRegistrationStrategy(DPCMS_CONNECTION connection)
            {
                _connection = connection;
            }

            public void Register(string firstname, string lastname, string email, string password,
                                 string CNIC, string phone, string address, string license)
            {
                try
                {
                    string sql = "INSERT INTO staff_registration (firstname, lastname, email, pasword, CNIC, phone, addres, license, designation) " +
                             "VALUES (@firstname, @lastname, @email, @pasword, @CNIC, @phone, @addres, @license, @designation)";

                    using (SqlCommand cmd = new SqlCommand(sql, _connection.con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pasword", password);
                        cmd.Parameters.AddWithValue("@CNIC", CNIC);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addres", address);
                        cmd.Parameters.AddWithValue("@license", license);
                        cmd.Parameters.AddWithValue("@designation", "Admin");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin Registration successful!");
                            Form1 login = new Form1();
                            login.Show();
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);                    
                }
            }
        }
    }
}


