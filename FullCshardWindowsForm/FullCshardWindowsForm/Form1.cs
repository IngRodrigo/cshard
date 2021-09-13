using Emcapcilacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encapsulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeName = txtName.Text;
            employee.EmployeAge = Convert.ToInt32(txtAge.Text);
            employee.EmployeePosition = txtPosition.Text;

            FrmEmployeeDetails vistaDetalle = new FrmEmployeeDetails();

            vistaDetalle.label2.Text = employee.EmployeeName;
            vistaDetalle.label3.Text = employee.EmployeAge.ToString();
            vistaDetalle.label4.Text = employee.EmployeePosition;

            vistaDetalle.ShowDialog();
        }

    }
}
