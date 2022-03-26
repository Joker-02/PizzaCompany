using PizzaCompany.Classes.Composite;
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
using PizzaCompany.Classes.Employees;
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.EmployeeForms
{
    public partial class EmployeeForm : KryptonForm
    {
        private Manager manager =new Manager();
        private readonly SqlConnection conn;
        private SqlCommand cmd;
        private readonly MenuForm form;
        BindingSource source=new BindingSource();
        public EmployeeForm(SqlConnection conn,MenuForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            getdata(manager);
            try
            {
                source.DataSource = manager.GetEmployees();
                dataGridView1.DataSource = source;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnView.Click += BtnView_Click;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Delete From Employee where Id='{dataGridView1.CurrentRow.Cells[0].Value}'";
                DialogResult dialogResult = MessageBox.Show("Are you sure?\n yes.delete no.canel", "Are you sure?", MessageBoxButtons.YesNo);
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
           search(manager,txtSearch.Text);
           source.DataSource = null; dataGridView1.DataSource = null;
            source.DataSource = manager.GetEmployees();
            dataGridView1.DataSource = source;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnView.PerformClick();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            ViewEmployee viewEmployee = new ViewEmployee(this,dataGridView1.CurrentRow);
            viewEmployee.Show();
            this.Hide();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditEmployee editEmployee = new EditEmployee(conn, this, dataGridView1.CurrentRow);
            editEmployee.Show();
            //this.Hide();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewEmForm newEmForm = new NewEmForm(conn, this);
            newEmForm.Show();
            this.Hide();
        }

        public void refresh()
        {
            source.DataSource=null; dataGridView1.DataSource = null;
            getdata(manager);
            source.DataSource = manager.GetEmployees();
            dataGridView1.DataSource=source;
        }
        void getdata(Manager manager)
        {
            try
            {
                if (manager.EmployeeCount() > 0) manager.ClearEmployee();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * From Employee order by Id";
                Employee employee;
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["Position"].ToString().Equals("Manager"))
                        {
                            employee = new Manager(dr["Id"].ToString()
                                ,dr["EmpName"].ToString(),
                                dr["Email"].ToString(),dr["EmpPassword"].ToString(),
                                (byte[])dr["Picture"]
                                );
                        }
                        else
                        {
                            employee = new Staff(dr["Id"].ToString()
                                                            , dr["EmpName"].ToString(),
                                                            dr["Email"].ToString(), dr["EmpPassword"].ToString(),
                                                            (byte[])dr["Picture"]
                                                            );
                        }
                        manager.AddEmployee(employee);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void search(Manager manager,string field)
        {
            try
            {
                if (manager.EmployeeCount() > 0) manager.ClearEmployee();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Select * From Employee Where EmpName Like'{field}%'";
                Employee employee;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["Position"].ToString().Equals("Manager"))
                        {
                            employee = new Manager(dr["Id"].ToString()
                                , dr["EmpName"].ToString(),
                                dr["Email"].ToString(), dr["EmpPassword"].ToString(),
                                (byte[])dr["Picture"]
                                );
                        }
                        else
                        {
                            employee = new Staff(dr["Id"].ToString()
                                                            , dr["EmpName"].ToString(),
                                                            dr["Email"].ToString(), dr["EmpPassword"].ToString(),
                                                            (byte[])dr["Picture"]
                                                            );
                        }
                        manager.AddEmployee(employee);
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
