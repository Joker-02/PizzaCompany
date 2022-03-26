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
using PizzaCompany.Classes.abstracts;
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.ProductForms
{
    public partial class PrductForm : KryptonForm
    {
        private readonly MenuForm m_menuForm;
        private  SqlConnection conn;
        private SqlCommand cmd;
        List<Product> products=new List<Product>();
        BindingSource source =new BindingSource();
        SqlDataAdapter appt;
        DataTable dt=new DataTable();
        public PrductForm(SqlConnection conn,MenuForm menuForm)
        {
            InitializeComponent();
            this.conn = conn;
            this.m_menuForm = menuForm;
            // getdata(products);
            //source.DataSource=products;
            //dataGridView1.DataSource=products;
            getdataApt(dt);
            source.DataSource = dt;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            this.FormClosed += PrductForm_FormClosed;
            btnView.Click += BtnView_Click;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnView.PerformClick();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            ViewProduct viewProduct = new ViewProduct(dataGridView1.CurrentRow);
            viewProduct.Show();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                appt = new SqlDataAdapter("select * from Product where Name like '" + txtSearch.Text + "%'", conn);
                
                appt.Fill(dt);
                dataGridView1.DataSource = dt;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_menuForm.Show();
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Delete from Product where Id={dataGridView1.CurrentRow.Cells[0].Value}";
                DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    refresh();
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditProduct editProduct = new EditProduct(conn, this, dataGridView1.CurrentRow);
            editProduct.ShowDialog();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewProduct newProduct =new NewProduct(conn, this);
            newProduct.Show();
        }

        public void getdata(List<Product> products)
        {
            try
            {
                if (products.Count > 0) products.Clear();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * From Product order by Id";
              
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        products.Add(new Product() {Id=(int)dr["Id"],
                            Type=int.Parse(dr["Cat_id"].ToString()),
                            Name=dr["Name"].ToString(),
                            Description=dr["Description"].ToString(),
                            Price=float.Parse(dr["Price"].ToString()),
                            Picture=(byte[])dr["Picture"]});
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getdataApt(DataTable dt)
        {
            if (dt.Rows.Count > 0) dt.Rows.Clear();
            appt = new SqlDataAdapter("select * from Product Order by Id", conn);
            
            
            appt.Fill(dt);
        }
        public void refresh()
        {
            //getdata(products);
            getdataApt(dt);
            source.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            source.DataSource = dt;
            dataGridView1.DataSource = dt;
          //  UpdateFont();
        }
    }
}
