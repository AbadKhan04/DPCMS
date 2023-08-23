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
    public partial class taxi : Form
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();

        public taxi()
        {
            InitializeComponent();
            button4.Enabled = false;
        }

        //Applying State Pattern (Behaverial Pattern)
        //The State design pattern allows an object to
        //alter its behavior when its internal state changes.


        ContextOfState Context = new ContextOfState();
        StartState startstate = new StartState();
        StopState stopstate = new StopState();

        public void setDGV()
        {
            connection.insert_Connection_string("server=DESKTOP-NAO1922;Database=DP_Cap;Integrated Security=True");
            connection.connect_open();
            Console.WriteLine("Connected to the database-taxi.");
            SqlDataAdapter da = new SqlDataAdapter(" select * from booking name", connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users ");
            dataGridView1.DataSource = ds.Tables[0];
            ds.Tables.Clear();
            connection.connect_close();

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (btnStatus.Text == "Turn on Cab")
            {
                Context.setState(startstate);
                State a = Context.getState();

                if (a.getState() == 1)
                {
                    label2.Text = "Online";
                    btnStatus.Text = "Turn off Cab";
                    btnPassenger.Text = "Check Rides Requests";
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                }
            }
            else
            {
                Context.setState(stopstate);
                State a = Context.getState();

                if (a.getState() == 0)
                {
                    label2.Text = "Offline";
                    btnStatus.Text = "Turn on Cabi Mode";
                    btnPassenger.Text = "Passengers Traffic";
                    button4.Enabled = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                }
            }
        }

        private void btnPassenger_Click(object sender, EventArgs e)
        {

            if (label2.Text == "Online")
            {
                ContextStratigy cs = new ContextStratigy(new Online());
                int status_checker = cs.execute_stratigy();
                setDGV();
                if (status_checker == 1)
                {
                    button4.Enabled = true;
                }
            }
            else if (label2.Text == "Offline")
            {
                ContextStratigy cs = new ContextStratigy(new Offline());
                int status_checker = cs.execute_stratigy();
                setDGV();
                if (status_checker == 0)
                {
                    button4.Enabled = false;
                }
            }
            else
            {

            }
        }
        private string pickup = "";
        private string destination = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                pickup = row.Cells["pickup"].Value.ToString();
                destination = row.Cells["destination"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                StringBuilder rowData = new StringBuilder();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    rowData.AppendLine($"{dataGridView1.Columns[cell.ColumnIndex].HeaderText}: {cell.Value}");
                }

                MessageBox.Show(rowData.ToString(), "Selected Row Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private DataGridViewRow selectedRow = null;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Left)
            {
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
            else
            {
                selectedRow = null;
            }
        }
    }
}
