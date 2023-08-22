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
    public partial class Manager : Form ,DecisionAPI
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        private string selectedTable;

        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Manager()
        {
            InitializeComponent();
            setDGV("staff_registration"); 
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
            //add booking table also
        }


        public void setDGV(string tableName)
        {
            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

                connection.connect_open();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tableName}", connection.con);
                DataSet ds = new DataSet();
                da.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[tableName];
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
        //APPLYING FACADE PATTERN (structural pattern) TO INSERT UPDATE AND DELETE
        //therefore it hides the complexities of the system from the client
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
                connection.connect_open();
                Console.WriteLine("Connected to the database-Manager.");


                string insert = "INSERT INTO staff_registration values ('" + txtfname.Text + "','" + txtlname.Text + "','" + txtmail.Text + "','" + txtpass.Text + "','" + txtcnic.Text + "','" + txtnumber.Text + "','" + txtaddress.Text + "','" + txtlicense.Text + "','" + comBrole.SelectedItem.ToString() + "')";
                

                if (selectedTable == "View Drivers")
                {
                    if (txtfname.Text != "" && txtpass.Text != "")
                    {
                        using (SqlCommand cmd = new SqlCommand(insert, connection.con))
                        {
                            cmd.Parameters.AddWithValue("@firstname", txtfname.Text);
                            cmd.Parameters.AddWithValue("@lastname", txtlname.Text);
                            cmd.Parameters.AddWithValue("@email", txtmail.Text );
                            cmd.Parameters.AddWithValue("@pasword",txtpass.Text);
                            cmd.Parameters.AddWithValue("@CNIC", txtcnic.Text);
                            cmd.Parameters.AddWithValue("@phone", txtnumber.Text);
                            cmd.Parameters.AddWithValue("@addres", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@license", txtlicense.Text);
                            cmd.Parameters.AddWithValue("@designation", comBrole.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();
                            connection.connect_close();
                            MessageBox.Show("Record Inserted Successfully");
                            setDGV(selectedTable);
                            setDGV("staff_registration");
                            ClearData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Provide Details!");
                    }
                }
                else if (selectedTable == "View Users")
                {
                    // Insert into user_registration
                    MessageBox.Show("Insert operation is not allowed for Users.");
                    return;
                }

                connection.connect_close();
                setDGV(selectedTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

                connection.connect_open();
                string update = "UPDATE staff_registration set firstname=@firstname,lastname=@lastname, email=@email,pasword=@pasword, CNIC=@CNIC,phone=@phone,addres=@addres,license=@license, designation=@designation  where staff_id=@staff_id";

                if (selectedTable == "View Drivers")
                {
                    if (txtfname.Text != "" && txtpass.Text != "")
                    {
                        using (SqlCommand cmd = new SqlCommand(update, connection.con))
                        {
                            cmd.Parameters.AddWithValue("@staff_id", ID);
                            cmd.Parameters.AddWithValue("@firstname", txtfname.Text);
                            cmd.Parameters.AddWithValue("@lastname", txtlname.Text);
                            cmd.Parameters.AddWithValue("@email", txtmail.Text);
                            cmd.Parameters.AddWithValue("@pasword", txtpass.Text);
                            cmd.Parameters.AddWithValue("@CNIC", txtcnic.Text);
                            cmd.Parameters.AddWithValue("@phone", txtnumber.Text);
                            cmd.Parameters.AddWithValue("@addres", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@license", txtlicense.Text);
                            cmd.Parameters.AddWithValue("@designation", comBrole.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();
                            connection.connect_close();
                            MessageBox.Show("Record Updated Successfully");
                            //setDGV("driver_registration");
                            ClearData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Update");
                    }

                }
                else if (selectedTable == "View Users")
                {
                    // Update user_registration
                }

                connection.connect_close();
                setDGV(selectedTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");

                connection.connect_open();
                string delete = "DELETE staff_registration where staff_id=@staff_id";
                if (selectedTable == "View Drivers")
                {
                    if (ID != 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(delete, connection.con))
                        {
                            cmd.Parameters.AddWithValue("@staff_id", ID);
                            cmd.ExecuteNonQuery();
                            connection.connect_close();
                            MessageBox.Show("Record Deleted Successfully");
                            //setDGV("driver_registration");
                            ClearData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete");
                    }


                }
                else if (selectedTable == "View Users")
                {
                    MessageBox.Show("Delete operation is not allowed for Users.");
                    return;
                }
                connection.connect_close();
                setDGV(selectedTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
