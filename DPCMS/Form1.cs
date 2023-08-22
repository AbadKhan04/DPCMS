using DPCMS;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DPCMS
{
    public partial class Form1 : Form
    {
        private IUserFactory userFactory;
        private IDriverFactory driverFactory;
        public Form1()
        {
            InitializeComponent();

            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
            userFactory = new UserFactory(connection);
            driverFactory = new DriverFactory(connection);
        }

        //APPLYING SINGLETON PATTERNED (Creational pattern) BASED CONNECTION CLASS

        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string loginInput = textBox1.Text;
                string password = textBox2.Text;

                IUser loggedInUser = userFactory.CreateUser(loginInput, password);
                IDriver loggedInDriver = driverFactory.CreateDriver(loginInput, password);

                if (loggedInUser != null)
                {
                    this.Hide();
                    User userForm = new User();
                    userForm.ShowDialog();
                }
                else if (loggedInDriver != null)
                {
                    string designation = loggedInDriver.GetDriverDesignation();

                    this.Hide();
                    if (designation == "Driver")
                    {
                        taxi taxiForm = new taxi();
                        taxiForm.ShowDialog();
                    }
                    else if (designation == "Admin")
                    {
                        Staff staffForm = new Staff();
                        staffForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid login credentials.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public interface IUserFactory
        {
            IUser CreateUser(string loginInput, string password);
        }

        // Interface for driver creation
        public interface IDriverFactory
        {
            IDriver CreateDriver(string loginInput, string password);
        }

        // Interface for user
        public interface IUser
        {
            // Add any user-specific methods or properties
            string GetUsername();
        }

        // UserImplementation class
        public class UserImplementation : IUser
        {
            private string _username;

            public UserImplementation(string username)
            {
                _username = username;
            }

            public string GetUsername()
            {
                return _username;
            }
        }

        // Interface for driver
        public interface IDriver
        {
            string GetDriverDesignation();
        }

        // DriverImplementation class
        public class DriverImplementation : IDriver
        {
            private string _driverDesignation;

            public DriverImplementation(string driverDesignation)
            {
                _driverDesignation = driverDesignation;
            }
            public string GetDriverDesignation()
            {
                return _driverDesignation;
            }

            // ... other properties and methods specific to driver
        }


        // User factory implementation
        public class UserFactory : IUserFactory
        {
            private DPCMS_CONNECTION _connection;

            public UserFactory(DPCMS_CONNECTION connection)
            {
                _connection = connection;
            }

            public IUser CreateUser(string loginInput, string password)
            {
                try
                {
                    _connection.connect_open();
                    Console.WriteLine("Connected to the database-Form1.");

                    string userSql = "SELECT * FROM user_registration WHERE (username = @loginInput OR email = @loginInput) AND pasword = @pasword";

                    using (SqlCommand userCmd = new SqlCommand(userSql, _connection.con))
                    {
                        userCmd.Parameters.AddWithValue("@loginInput", loginInput);
                        userCmd.Parameters.AddWithValue("@pasword", password);

                        using (SqlDataReader userDataReader = userCmd.ExecuteReader())
                        {
                            if (userDataReader.Read())
                            {
                                string username = userDataReader["username"].ToString();
                                string email = userDataReader["email"].ToString();

                                // Create an instance of UserImplementation using retrieved data
                                return new UserImplementation(username);
                            }
                            else
                            {
                                // User login failed
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    _connection.connect_close();
                }
            }
        }

        // Driver factory implementation
        public class DriverFactory : IDriverFactory
        {
            private DPCMS_CONNECTION _connection;

            public DriverFactory(DPCMS_CONNECTION connection)
            {
                _connection = connection;
            }

            public IDriver CreateDriver(string loginInput, string password)
            {
                try
                {
                    _connection.connect_open();
                    Console.WriteLine("Connected to the database-Form1.");

                    string driverSql = "SELECT * FROM staff_registration WHERE (email = @loginInput) AND pasword = @pasword";

                    using (SqlCommand driverCmd = new SqlCommand(driverSql, _connection.con))
                    {
                        driverCmd.Parameters.AddWithValue("@loginInput", loginInput);
                        driverCmd.Parameters.AddWithValue("@pasword", password);

                        using (SqlDataReader driverDataReader = driverCmd.ExecuteReader())
                        {
                            if (driverDataReader.Read())
                            {
                                string driverDesignation = driverDataReader["designation"].ToString();
                                return new DriverImplementation(driverDesignation);
                            }
                            else
                            {
                                // Driver login failed
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    _connection.connect_close();
                }
            }
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
