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


        //APPLYING Command PATTERN (behavioral pattern) to  encapsulate the booking action as a command.   *
        public interface ICommand
        {
            void Execute();
        }

        public class BookRideCommand : ICommand
        {
            private readonly DPCMS_CONNECTION _connection;
            private readonly string _pickup;
            private readonly string _destination;
            private readonly string _fare;
            private readonly string _ridetype;

            public BookRideCommand(DPCMS_CONNECTION connection, string pickup, string destination, string fare, string ridetype)
            {
                _connection = connection;
                _pickup = pickup;
                _destination = destination;
                _fare = fare;
                _ridetype = ridetype;
            }

            public void Execute()
            {
                try
                {
                    _connection.connect_open();
                    Console.WriteLine("Connected to the database-user.");

                    string sql = "INSERT INTO booking (pickup, destination, fare, ridetype) " +
                                 "VALUES (@pickup, @destination, @fare, @ridetype)";

                    using (SqlCommand cmd = new SqlCommand(sql, _connection.con))
                    {
                        cmd.Parameters.AddWithValue("@pickup", _pickup);
                        cmd.Parameters.AddWithValue("@destination", _destination);
                        cmd.Parameters.AddWithValue("@fare", _fare);
                        cmd.Parameters.AddWithValue("@ridetype", _ridetype);

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
                    _connection.connect_close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnride_Click(object sender, EventArgs e)
        {
            ICommand bookRideCommand = new BookRideCommand(connection, txtpick.Text, txtdestination.Text, txtfare.Text, comboBox1.SelectedItem.ToString());
            bookRideCommand.Execute();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
