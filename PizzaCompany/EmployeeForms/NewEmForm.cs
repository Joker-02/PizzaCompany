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
using System.IO;
using PizzaCompany.Classes;

namespace PizzaCompany.EmployeeForms
{
    public partial class NewEmForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        private readonly EmployeeForm employee;
        string position = null;
        public NewEmForm(SqlConnection con,EmployeeForm employee)
        {
            InitializeComponent();
            this.con = con;
            this.employee = employee;
            btnInsert.Click += btnInsertClick;
            btnInsertImage.Click += btnInsertImageClick;
            btnClear.Click += btnClearClick;
            comboBox1.Items.AddRange(new string[] { "Manager", "Staff" });
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.FormClosed += NewEmForm_FormClosed;
            pictureBox1.MouseDoubleClick += PictureBox1_MouseDoubleClick;
            txtID.Text = "E00";

        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnInsertImage.PerformClick();
        }

        private void NewEmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            employee.Show();
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (comboBox1.SelectedItem.ToString() == "Manager")
                {
                    position = "Manager";
                }
                if (comboBox1.SelectedItem.ToString() == "Staff")
                {
                    position = "Staff";
                }
            }
            
        }

        private void btnClearClick(object sender, EventArgs e)
        {
            
            txtID.Text = "E00";
            txtName.Text = "";
            txtEmail.Text = "";
            pictureBox1.Image = null;
            comboBox1.SelectedIndex = -1;
        }

        private void btnInsertImageClick(object sender, EventArgs e)
        {
            try 
            {
                using (OpenFileDialog openFile = new OpenFileDialog()
                    {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...",
                    Multiselect = false
                }
                    
                    )
                {
                    if(openFile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(openFile.FileName);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       
        private void btnInsertClick(object sender, EventArgs e)
        {
            try
            {
                if (Validation.validateEmail(txtEmail.Text) == false) throw new Exception("Invalid email");
                if (Validation.validatePassword(txtPassword.Text) == false) throw new Exception("Password must be at least \n" +
                     "8-20 in length\n 1 upper cast letter\n 1 lower cast letter \n 1 number \n 1 special charector");
                if (Validation.validateField(txtName.Text) == false ||
                    Validation.validateField(txtID.Text) == false 
                    ) throw new Exception("Field can not be empty");
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "InsertEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = txtID.Text;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = position;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
                cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = convertImagetoByte(pictureBox1.Image);
                cmd.ExecuteNonQuery();
                MessageBox.Show("successfully Added");
                employee.refresh();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] convertImagetoByte(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            }
        }
        private Image convertBytetoImage(byte[] data)
        {
            using (MemoryStream m = new MemoryStream(data))
            {
                return Image.FromStream(m);
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
