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
    public partial class Staff : Form
    {
        //APPLYING Bridge Pattern (structural pattern) for calling managers and driver
        //separates the abstraction hierarchy and

        public Staff()
        {
            InitializeComponent();
        }

        //Abstraction and Implementor Interfaces:
        public interface IAbstraction
        {
            void Open();
        }
        public interface IImplementor
        {
            void OpenForm();
        }

        //Create Concrete Implementors:
        public class ManagerImplementor : IImplementor
        {
            public void OpenForm()
            {
                Manager managerForm = new Manager();
                managerForm.Show();
            }
        }
        public class DriverImplementor : IImplementor
        {
            public void OpenForm()
            {
                taxi driverForm = new taxi();
                driverForm.Show();
            }
        }

        //Create Concrete Abstractions:
        public class Employ : IAbstraction
        {
            private readonly IImplementor _implementor;

            public Employ(IImplementor implementor)
            {
                _implementor = implementor;
            }

            public void Open()
            {
                _implementor.OpenForm();
            }
        }

        public class Taxi : IAbstraction
        {
            private readonly IImplementor _implementor;

            public Taxi(IImplementor implementor)
            {
                _implementor = implementor;
            }

            public void Open()
            {
                _implementor.OpenForm();
            }
        }

        //Abstractions in Your Form:
        private void button1_Click(object sender, EventArgs e)
        {
            IImplementor managerImplementor = new ManagerImplementor();
            IAbstraction manager = new Employ(managerImplementor);
            manager.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IImplementor driverImplementor = new DriverImplementor();
            IAbstraction driver = new Taxi(driverImplementor);
            driver.Open();
        }
    }
}
