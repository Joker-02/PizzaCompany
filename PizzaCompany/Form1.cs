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
using Pizza_Company.Sigleton;
using PizzaCompany.Classes.abstracts;
using Pizza_Company.Classes.Pizzas;
using Pizza_Company.Topping;
using Pizza_Company.Classes.Crusts;
using Pizza_Company.Classes.PizzaSize;
using PizzaCompany.Classes.Employees;
using ComponentFactory.Krypton.Toolkit;
namespace PizzaCompany
{
    public partial class Form1 : KryptonForm
    {
        private SqlConnection _conn;
        private SqlCommand _cmd;
        public Form1()
        {
            InitializeComponent();
            connect();
        
           
            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm=new RegisterForm(_conn,this);
            registerForm.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Field Can not be Empty");
            }
            else
            {
                _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandText = $"Select * from Employee where Email='{txtUsername.Text}' and EmpPassword='{txtPassword.Text}'";
                try
                {
                    int i = _cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MenuForm menuForm = new MenuForm(_conn, this,reader["Position"].ToString());
                            menuForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("wrong password or email");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
        private void connect()
        {
            try
            {
                Connector connector=Connector.GetConnector();
                if (connector != null)
                {
                    _conn = connector.GetConnection();
                    _conn.Open();
                  // MessageBox.Show("Connected");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
