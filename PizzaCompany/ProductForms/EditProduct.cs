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
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.ProductForms
{
    public partial class EditProduct : KryptonForm
    {
        private readonly SqlConnection conn;
        private readonly PrductForm form;
        int type,id;
        SqlCommand cmd;
        public EditProduct(SqlConnection conn,PrductForm prductForm,DataGridViewRow row)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = prductForm;
            comboBox1.Items.AddRange(new string[] {"Pizza","Drink" });
            filldata(row);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            btnEdit.Click += BtnEdit_Click;
            btnClear.Click += btnClearClick;
            btnInsertimage.Click += btnInsertimageClick;
           
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


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        private void Edit()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = type;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = float.Parse(txtPrice.Text);
                cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = CovertImage.CovertImagetoByte(pictureBox1.Image);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully Editted Product");
                form.refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void filldata(DataGridViewRow row)
        {
            try
            {
                id=int.Parse( row.Cells[0].Value.ToString());
                txtName.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = string.Format("{0:C}", row.Cells[4].Value.ToString());
                if (row.Cells[1].Value.Equals(1))
                {
                    comboBox1.SelectedIndex = 1;
                }
                if (row.Cells[1].Value.Equals(2))
                {
                    comboBox1.SelectedIndex = 0;
                }
                pictureBox1.Image = CovertImage.convertBytetoImage((byte[])row.Cells[5].Value);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
