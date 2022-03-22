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
    public partial class ReportForm : Form
    {
        readonly SqlConnection conn;
        readonly MenuForm menuForm;
        SqlCommand cmd;
        BindingSource source=new BindingSource();
        List<Order> orders=new List<Order>();
        public ReportForm(SqlConnection conn,MenuForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.menuForm = form;
            getdata(orders);
            source.DataSource=orders;
            dataGridView1.DataSource = source;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            textBox1.TextChanged += TextBox1_TextChanged;
            dateTimePicker1.TextChanged += DateTimePicker1_TextChanged;
            button1.Click += Button1_Click;
            this.FormClosed += ReportForm_FormClosed;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Parse(dateTimePicker1.Text);
            reportsprint reportsprint = new reportsprint(conn, dateTime);
            reportsprint.ShowDialog();
        }

        private void DateTimePicker1_TextChanged(object sender, EventArgs e)
        {
            DateTime dateTime =DateTime.Parse(dateTimePicker1.Text);
          //  MessageBox.Show(dateTime.ToString("yyyy-MM-dd"));
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
                source.DataSource = null;
                dataGridView1.DataSource = null;
                source.DataSource = orders;
                dataGridView1.DataSource = source;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (orders.Count > 0) orders.Clear();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Select * from Orders where Description like '{textBox1.Text}%'" ;
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
                source.DataSource = null;
                dataGridView1.DataSource = null;
                source.DataSource = orders;
                dataGridView1.DataSource = source;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuForm.Show();
        }

        private void getdata(List<Order> orders)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * from Orders order by Order_Date";
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
