using ComponentFactory.Krypton.Toolkit;
using PizzaCompany.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaCompany.ProductForms
{
    public partial class ViewProduct : KryptonForm
    {
        public ViewProduct(DataGridViewRow row)
        {
            InitializeComponent();
            filldata(row);
        }
        void filldata(DataGridViewRow row)
        {
            try
            {
             
                txtName.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = string.Format("{0:C}", row.Cells[4].Value.ToString());
                if (row.Cells[1].Value.Equals(1))
                {
                    textBox1.Text = "Drink";
                }
                if (row.Cells[1].Value.Equals(2))
                {
                    textBox1.Text = "Pizza";
                }
                pictureBox1.Image = CovertImage.convertBytetoImage((byte[])row.Cells[5].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
