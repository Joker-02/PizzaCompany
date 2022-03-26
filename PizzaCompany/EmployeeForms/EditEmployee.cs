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
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.EmployeeForms
{
    public partial class EditEmployee : KryptonForm
    {
        SqlConnection con;
        SqlCommand cmd;
        private readonly EmployeeForm employee;
        string position = null;
        public EditEmployee(SqlConnection con,EmployeeForm employee,DataGridViewRow row)
        {
            InitializeComponent();
            this.con = con;
            this.employee = employee;
            btnEdit.Click += btnInsertClick;
            btnInsertImage.Click += btnInsertImageClick;
            btnClear.Click += btnClearClick;
            comboBox1.Items.AddRange(new string[] { "Manager", "Staff" });
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.FormClosed += NewEmForm_FormClosed;
            pictureBox1.MouseDoubleClick += PictureBox1_MouseDoubleClick;
            datafill(row);

        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnInsertImage.PerformClick();
        }

        private void NewEmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            employee.Show();
            
        }
        private void datafill(DataGridViewRow row)
        {
            try
            {
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPassword.Text=row.Cells[4].Value.ToString();
                if (row.Cells[2].Value.ToString() == "Manager")
                {
                    comboBox1.SelectedIndex = 0;

                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                pictureBox1.Image = convertBytetoImage((byte[])row.Cells[5].Value);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (comboBox1.SelectedItem.ToString() == "Manager")
                {
                    position = "Manager";
                    MessageBox.Show(position);
                }
                if (comboBox1.SelectedItem.ToString() == "Staff")
                {
                    position = "Staff";
                    MessageBox.Show(position);
                }
            }
            
        }

        private void btnClearClick(object sender, EventArgs e)
        {
            
            //txtID.Text = "";
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
               
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UpdateEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = txtID.Text;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;          
                cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = position;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
                cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = convertImagetoByte(pictureBox1.Image);
                cmd.ExecuteNonQuery();
                MessageBox.Show("successfully Updateed");
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
