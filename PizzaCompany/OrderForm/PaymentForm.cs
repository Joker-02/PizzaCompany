using Microsoft.Reporting.WinForms;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaCompany.OrderForm
{
    public partial class PaymentForm : Form
    {
        List<Product> products = new List<Product>();
        BindingSource source=new BindingSource();
        public PaymentForm(List<Product> products)
        {
            InitializeComponent();
            this.products = products;
            source.DataSource = products;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[] {
            new Microsoft.Reporting.WinForms.ReportParameter("ptotalprice",products.Sum(p=>p.Price).ToString("C")),
            new Microsoft.Reporting.WinForms.ReportParameter("pDate",DateTime.Now.ToString("yyyy-MM-dd")),
            new ReportParameter("ptotalQty",products.Count().ToString()),
            new ReportParameter("pQty","1")

            };

                this.reportViewer1.LocalReport.SetParameters(parameters);
                var reportDataSource = new ReportDataSource("Product", source);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
