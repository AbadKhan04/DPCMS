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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

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


            //dont take null
            //if (!string.IsNullOrWhiteSpace(loginInput) && !string.IsNullOrWhiteSpace(password))
            //{
            //    bool loggedIn = false;
            //}
            //else
            //{
            //    MessageBox.Show("Please enter both username/email and password.");
            //}
            try
            {
                string loginInput = textBox1.Text;
                string password = textBox2.Text;

                string userSql = "SELECT * FROM user_registration WHERE (username = @loginInput OR email = @loginInput) AND pasword = @pasword";
                string driverSql = "SELECT * FROM staff_registration WHERE (email = @loginInput) AND pasword = @pasword";

                connection.connect_open();
                Console.WriteLine("Connected to the database-Form1.");

                using (SqlCommand userCmd = new SqlCommand(userSql, connection.con))
                using (SqlCommand driverCmd = new SqlCommand(driverSql, connection.con))
                {
                    userCmd.Parameters.AddWithValue("@loginInput", loginInput);
                    userCmd.Parameters.AddWithValue("@pasword", password);

                    driverCmd.Parameters.AddWithValue("@loginInput", loginInput);
                    driverCmd.Parameters.AddWithValue("@pasword", password);

                    using (SqlDataReader userDataReader = userCmd.ExecuteReader())
                    {
                        if (userDataReader.Read())
                        {
                            connection.con.Close();
                            this.Hide();
                            User userForm = new User();
                            userForm.ShowDialog();
                            return;
                        }
                    }
                    using (SqlDataReader driverDataReader = driverCmd.ExecuteReader())
                    {
                        if (driverDataReader.Read())
                        {
                            string designation = driverDataReader["designation"].ToString();
                            connection.con.Close();
                            this.Hide();
                            if (designation == "Driver")
                            {
                                taxi taxi = new taxi();
                                taxi.ShowDialog();
                            }
                            else if (designation == "Admin")
                            {
                                Manager admin = new Manager();
                                admin.ShowDialog();
                            }

                            return;
                        }
                    }
                }

                connection.con.Close();
                MessageBox.Show("Invalid login credentials.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        ////APPLYING FACTORY PATTERN  (Creational pattern) TO GENERATE USERS ,STAFF OR CABI

        //String sql = "select * from c_login where username='" + textBox1.Text + "' and pword = '" + textBox2.Text + "'";


        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, connection.con);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        LoginFactory lf = new LoginFactory();

        //        if (dr.Read())
        //        {
        //            //string j_i = dr["job_id"].ToString();
        //            int id = Convert.ToInt16(dr["login_id"]);
        //            string designation = dr["designation"].ToString();
        //            if (designation == "User")
        //            {
        //                login l1 = lf.getLogin(designation);
        //                l1.openform();
        //                connection.con.Close();
        //                this.Hide();

        //            }
        //            else if (designation == "Staff")
        //            {
        //                login l1 = lf.getLogin(designation);
        //                l1.openform();
        //                connection.con.Close();
        //                this.Hide();

        //            }
        //            else if (designation == "Cabi")
        //            {
        //                login l1 = lf.getLogin(designation);
        //                l1.openform();
        //                connection.con.Close();
        //                this.Hide();

        //            }


        //            // dr.Close();

        //            connection.connect_close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("YOU USENAME OR PASSWORD IS INCORRECT");
        //        }
        //        dr.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
