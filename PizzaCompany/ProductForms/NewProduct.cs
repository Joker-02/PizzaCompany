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
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.ProductForms
{
    public partial class NewProduct : KryptonForm
    {
        SqlConnection con;
        SqlCommand cmd;
        private readonly  PrductForm productForms;
        int type;
        public NewProduct(SqlConnection con,PrductForm productForms)
        {
            InitializeComponent();
            this.con = con;
            this.productForms = productForms;
            btnInsert.Click += btnInsertClick;
            btnInsertimage.Click += btnInsertimageClick;
            pictureBox1.DoubleClick += pictureBox1DoubleClick;
            btnClear.Click += btnClearClick;
            comboBox1.Items.Add("Pizza");
            comboBox1.Items.Add("Drink");
            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (comboBox1.SelectedItem.Equals("Drink"))
                {
                    type = 1;
                }
                if (comboBox1.SelectedItem.Equals("Pizza"))
                {
                    type = 2;
                }
            }
        }

        private void btnClearClick(object sender, EventArgs e)
        {
         
            txtName.Text = "";
            txtPrice.Text = "";
            comboBox1.SelectedIndex = -1;
            pictureBox1.Image = null;
        }

        private void pictureBox1DoubleClick(object sender, EventArgs e)
        {
            btnInsertimage.PerformClick();
        }

        private void btnInsertimageClick(object sender, EventArgs e)
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

        private void btnInsertClick(object sender, EventArgs e)
        {
            try 
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "InsertProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = type;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = float.Parse(txtPrice.Text);
                cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = convertImagetoByte(pictureBox1.Image);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully added Product");
                productForms.refresh();
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
    }
}
