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
    public partial class ViewEmployee : KryptonForm
    {
        private readonly EmployeeForm employee;
        string position = null;
        public ViewEmployee(EmployeeForm employee,DataGridViewRow row)
        {
            InitializeComponent();
            this.employee = employee;
           
  
   

            this.FormClosed += NewEmForm_FormClosed;

            datafill(row);

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
                    txtPosition.Text = "Manager";

                }
                else
                {
                    txtPosition.Text = "Staff";
                }
                pictureBox1.Image = convertBytetoImage((byte[])row.Cells[5].Value);
            }catch (Exception ex)
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
