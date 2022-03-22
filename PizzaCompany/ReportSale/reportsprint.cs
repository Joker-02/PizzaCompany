using Microsoft.Reporting.WinForms;
using PizzaCompany.Classes;
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

namespace PizzaCompany.ReportSale
{
    public partial class reportsprint : Form
    {
        private readonly SqlConnection conn;
        readonly DateTime dateTime;
        BindingSource bindingSource=new BindingSource();
        List<Order> list = new List<Order>();
        SqlCommand cmd;
        public reportsprint(SqlConnection conn,DateTime dateTime)
        {
            InitializeComponent();
            this.conn = conn;
            this.dateTime = dateTime;
            getdata(list);
            bindingSource.DataSource= list;
        }
        private void getdata(List<Order> orders)
        {
            try
            {
                if (orders.Count > 0) orders.Clear();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Select * from Orders where Order_Date like '{dateTime.ToString("yyyy-MM-dd")}%'";
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = int.Parse(dr["Id"].ToString())
                        ,
                            Description = dr["Description"].ToString()
                        ,
                            Price = double.Parse(dr["Price"].ToString()),
                            Date = DateTime.Parse(dr["Order_date"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void reportsprint_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[] {
            new Microsoft.Reporting.WinForms.ReportParameter("ptotalprice",list.Sum(o=>o.Price).ToString("C")),
            new Microsoft.Reporting.WinForms.ReportParameter("pDate",dateTime.ToString("yyyy-MM-dd")),
            new Microsoft.Reporting.WinForms.ReportParameter("ptotalQty",list.Count.ToString()),

            };

            this.reportViewer1.LocalReport.SetParameters(parameters);
            var reportDataSource = new ReportDataSource("Order", bindingSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }
    }
}
