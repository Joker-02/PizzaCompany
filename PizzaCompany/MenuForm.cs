using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ComponentFactory.Krypton.Toolkit;
namespace PizzaCompany
{
    public partial class MenuForm : KryptonForm
    {
        private readonly Form1 _form1;
        private  SqlConnection _conn;
        Timer timer = new Timer();
        public MenuForm(SqlConnection conn,Form1 loginform,string position)
        {
            InitializeComponent();
            _conn = conn;
            _form1 = loginform;
            this.FormClosed += MenuForm_FormClosed;
            lProduct.Click += LProduct_Click;
            LEmp.Click += LEmp_Click;
            lOrder.Click += LOrder_Click;
            LReport.Click += LReport_Click;
            lExit.Click += LExit_Click;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
            label1.Focus();
            if (position.Equals("Manager"))
            {
                MessageBox.Show("Welcome Manger!");
            }
            else
            {
                MessageBox.Show("Welcome Staff");
                lProduct.Visible = false;
                LEmp.Visible = false;
                LReport.Visible=false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text ="Time: "+ DateTime.Now.ToString("hh:mm:ss:tt");
        }

        private void LExit_Click(object sender, EventArgs e)
        {

            string message = "Are you Sure you want to exit?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                this.Close();
                _form1.Show();
            }
        }

        private void LReport_Click(object sender, EventArgs e)
        {
            ReportSale.ReportForm reportForm = new ReportSale.ReportForm(_conn,this);
            reportForm.Show();
            this.Hide();
        }

        private void LOrder_Click(object sender, EventArgs e)
        {
            OrderForm.OrderForms orderForms = new OrderForm.OrderForms(_conn, this);
            orderForms.Show();
            this.Hide();
        }

        private void LEmp_Click(object sender, EventArgs e)
        {
            EmployeeForms.EmployeeForm employeeForm = new EmployeeForms.EmployeeForm(_conn, this);
            employeeForm.Show();
        }

        private void LProduct_Click(object sender, EventArgs e)
        {
            ProductForms.PrductForm prductForm = new ProductForms.PrductForm(_conn,this);
            prductForm.Show();
            this.Hide();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form1.Show();
        }
    }
}
