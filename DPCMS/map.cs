using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPCMS
{
    public partial class map : Form
    {
        public map()
        {
            InitializeComponent();
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            FeedBack Form = new FeedBack();
            Form.Show();
            this.Hide();
        }
    }
}
