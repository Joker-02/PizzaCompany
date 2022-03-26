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
using PizzaCompany.Classes;
using PizzaCompany.Classes.Employees;
using PizzaCompany.Classes.abstracts;
using ComponentFactory.Krypton.Toolkit;
namespace PizzaCompany
{
    public partial class RegisterForm : KryptonForm
    {
        private readonly Form1 form1;
        private readonly SqlConnection _conn;
       // Validation validation=new Validation();
        private SqlCommand _cmd;
        public RegisterForm(SqlConnection conn,Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            _conn = conn;
            this.FormClosed += RegisterForm_FormClosed;
            btnImg.Click += BtnImg_Click;
            pictureBox1.DoubleClick += PictureBox1_DoubleClick;
            btnRegister.Click += BtnRegister_Click;
        }
        void InsertStaff()
        {
          Employee employee = new Staff(txtId.Text, txtUsername.Text, txtEmail.Text, txtPassword.Text,CovertImage.CovertImagetoByte(pictureBox1.Image));
            try
            {
                _cmd = new SqlCommand();
                _cmd.Connection=_conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "InsertEmployee";
                _cmd.Parameters.Add("@id",SqlDbType.NVarChar).Value=employee.Id;
                _cmd.Parameters.Add("@name",SqlDbType.NVarChar).Value=employee.Name;
                _cmd.Parameters.Add("@position",SqlDbType.NVarChar).Value=employee.Position;
                _cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = employee.Email;
                _cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = employee.Password;
                _cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = employee.Picture;
                _cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Register");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation.validateEmail(txtEmail.Text) == false) throw new Exception("Invalid email");
                if (Validation.validatePassword(txtPassword.Text) == false) throw new Exception("Password must be at least \n" +
                     "8-20 in length\n 1 upper cast letter\n 1 lower cast letter \n 1 number \n 1 special charector");
                if (Validation.validateField(txtUsername.Text) == false ||
                    Validation.validateField(txtPass_con.Text) == false ||
                    Validation.validateField(txtId.Text)==false) throw new Exception("Field can not be empty");
                if (txtPassword.Text.Equals(txtPass_con.Text) == false) throw new Exception("password not match confirm password");
                InsertStaff();
               

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            btnImg.PerformClick();
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...",
                    Multiselect = false
                })
                {
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(openFile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
