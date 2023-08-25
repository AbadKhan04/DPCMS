using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DPCMS
{
    public partial class Manager : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        private string selectedTable;
        private DatabaseFacade databaseFacade;

        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Manager()
        {
            InitializeComponent();
            setDGV("staff_registration");
            databaseFacade = new DatabaseFacade();
        }

        //APPLYING FACADE PATTERN (structural pattern) TO INSERT UPDATE AND DELETE
        //therefore it hides the complexities of the system from the client
        class DatabaseFacade
        {
            private DPCMS_CONNECTION connection;

            public DatabaseFacade()
            {
                connection = DPCMS_CONNECTION.getinst();
            }

            public void Insert(string query, string firstName, string lastName, string email, string password, string cnic, string phone, string address, string license, string designation)
            {
                try
                {
                    connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
                    connection.connect_open();
                    Console.WriteLine("Connected to the database-Manager.");

                    using (SqlCommand cmd = new SqlCommand(query, connection.con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstName);
                        cmd.Parameters.AddWithValue("@lastname", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pasword", password);
                        cmd.Parameters.AddWithValue("@CNIC", cnic);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addres", address);
                        cmd.Parameters.AddWithValue("@license", license);
                        cmd.Parameters.AddWithValue("@designation", designation);

                        cmd.ExecuteNonQuery();
                    }
                    connection.connect_close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void Update(string query, int staffId, string firstName, string lastName, string email, string password, string cnic, string phone, string address, string license, string designation)
            {
                try
                {
                    connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
                    connection.connect_open();
                    Console.WriteLine("Connected to the database-Manager.");

                    using (SqlCommand cmd = new SqlCommand(query, connection.con))
                    {
                        cmd.Parameters.AddWithValue("@staff_id", staffId);
                        cmd.Parameters.AddWithValue("@firstname", firstName);
                        cmd.Parameters.AddWithValue("@lastname", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pasword", password);
                        cmd.Parameters.AddWithValue("@CNIC", cnic);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addres", address);
                        cmd.Parameters.AddWithValue("@license", license);
                        cmd.Parameters.AddWithValue("@designation", designation);

                        cmd.ExecuteNonQuery();
                    }

                    connection.connect_close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void Delete(string query, int staffId)
            {
                try
                {
                    connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
                    connection.connect_open();
                    Console.WriteLine("Connected to the database-Manager.");

                    using (SqlCommand cmd = new SqlCommand(query, connection.con))
                    {
                        cmd.Parameters.AddWithValue("@staff_id", staffId);
                        cmd.ExecuteNonQuery();
                    }

                    connection.connect_close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = comboBox.SelectedItem.ToString();
            if (selectedTable == "View Drivers")
            {
                setDGV("staff_registration");
            }
            else if (selectedTable == "View Users")
            {
                setDGV("user_registration");
            }
            else if (selectedTable == "View Bookings")
            {
                setDGV("booking");
            }
        }

        public void setDGV(string tableName)
        {
            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

                connection.connect_open();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM [{tableName}]", connection.con);
                DataSet ds = new DataSet();
                da.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Tables.Clear();
                connection.connect_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Clear Data  
        private void ClearData()
        {
            ID = 0;
            txtfname.Text = "";
            txtlname.Text = "";
            txtmail.Text = "";
            txtpass.Text = "";
            txtcnic.Text = "";
            txtnumber.Text = "";
            txtaddress.Text = "";
            txtlicense.Text = "";
            comBrole.SelectedItem = null;
        }
        private void Manager_Load(object sender, EventArgs e)
        {

        }
        public void getworker()
        {
            this.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO [staff_registration] values ('" + txtfname.Text + "','" + txtlname.Text + "','" + txtmail.Text + "','" + txtpass.Text + "','" + txtcnic.Text + "','" + txtnumber.Text + "','" + txtaddress.Text + "','" + txtlicense.Text + "','" + comBrole.SelectedItem.ToString() + "')";
            string firstName = txtfname.Text;
            string lastName = txtlname.Text;
            string email = txtmail.Text;
            string password = txtpass.Text;
            string cnic = txtcnic.Text;
            string phone = txtnumber.Text;
            string address = txtaddress.Text;
            string license = txtlicense.Text;
            string designation = comBrole.SelectedItem.ToString();

            databaseFacade.Insert(insertQuery, firstName, lastName, email, password, cnic, phone, address, license, designation);
            // Refresh the DataGridView data after inserting
            setDGV(selectedTable);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE [staff_registration] set firstname=@firstname,lastname=@lastname, email=@email,pasword=@pasword, CNIC=@CNIC,phone=@phone,addres=@addres,license=@license, designation=@designation  where staff_id=@staff_id";
            int staffId = ID;
            string firstName = txtfname.Text;
            string lastName = txtlname.Text;
            string email = txtmail.Text;
            string password = txtpass.Text;
            string cnic = txtcnic.Text;
            string phone = txtnumber.Text;
            string address = txtaddress.Text;
            string license = txtlicense.Text;
            string designation = comBrole.SelectedItem.ToString();

            databaseFacade.Update(updateQuery, staffId, firstName, lastName, email, password, cnic, phone, address, license, designation);
            // Refresh the DataGridView data after inserting
            setDGV(selectedTable);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE [staff_registration] where staff_id=@staff_id";
            int staffId = ID;

            databaseFacade.Delete(deleteQuery, staffId);
            // Refresh the DataGridView data after inserting
            setDGV(selectedTable);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
                connection.connect_open();

                if (selectedTable == "View Drivers")
                {

                }
                else if (selectedTable == "View Users")
                {

                }
                connection.connect_close();
                setDGV(selectedTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtfname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtpass.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcnic.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtnumber.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtlicense.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comBrole.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
