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
using PizzaCompany.Classes.Drinks;
using Pizza_Company.Classes.Pizzas;
using PizzaCompany.Classes;
using Pizza_Company.Classes.PizzaSize;
using Pizza_Company.Topping;
using Pizza_Company.Classes.Crusts;
using ComponentFactory.Krypton.Toolkit;

namespace PizzaCompany.OrderForm
{
    public partial class OrderForms : KryptonForm
    {
        List<string> category = new List<string>();
        List<int> cat = new List<int>();
        private readonly MenuForm form;
        private readonly SqlConnection conn;
        SqlCommand cmd;
        List<Product> products= new List<Product>();
        List<Drink> drinks= new List<Drink>();
        List<Pizza> pizzas= new List<Pizza>();
        getProduct Product;
        public OrderForms(SqlConnection conn,MenuForm form)
        {
            InitializeComponent();
            this.conn = conn;
            this.form = form;
            this.FormClosed += OrderForms_FormClosed;
            getcategory();
            listView1.View = View.Details;
            listView1.Columns.Add("Descrption", 350);
            listView1.Columns.Add("Price", 180);
            listView1.Columns.Add("Qty", 80);
            listView1.FullRowSelect = true;
            listView1.MouseClick += ListView1_MouseClick;
            btnSizeS.Click += BtnSizeS_Click;
            btnSizeM.Click += BtnSizeM_Click;
            btnSizeL.Click += BtnSizeL_Click;
            btnTBBQ.Click += BtnTBBQ_Click;
            btnTTomato.Click += BtnTTomato_Click;
            btnTPaneer.Click += BtnTPaneer_Click;
            btnThinCrust.Click += BtnThinCrust_Click;
            btnHandTossed.Click += BtnHandTossed_Click;
            btnCrustCheese.Click += BtnCrustCheese_Click;
            btnCrustHotDog.Click += BtnCrustHotDog_Click;
            btnPay.Click += BtnPay_Click;
            btnClear.Click += BtnClear_Click;
            setStateSize(false);
            setStateTopping(false, false, false);
            setStateCrust(false, false, false, false);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (drinks.Count > 0) drinks.Clear();
            if(pizzas.Count>0)pizzas.Clear();
            if (products.Count > 0) products.Clear();
            listView1.Items.Clear();
            LQty.Text = "Qty:";
            LTotal.Text = "Total:";
            j = 0;
            i = 0;
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (products.Count > 0) products.Clear();
            if (drinks.Count > 0)
            {
                foreach (var drink in drinks)
                    products.Add(new Product(drink));
            }
            if (pizzas.Count > 0)
            {
                foreach (var pizza in pizzas)
                    products.Add(new Product(pizza));
            }
            InsertOrder(products);
            PaymentForm paymentForm = new PaymentForm(products);
            paymentForm.ShowDialog();
        }
        private void InsertOrder(List<Product> items)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandText = $"Insert into Orders values('{item.Description}',{item.Price},'{DateTime.Now.ToString()}')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void BtnCrustHotDog_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new Chesse(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnCrustCheese.Enabled = false;
            btnCrustHotDog.Enabled = false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnCrustCheese_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new Chesse(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnCrustCheese.Enabled = false;
            btnCrustHotDog.Enabled = false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnHandTossed_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new HandTossed(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnHandTossed.Enabled = false;
            btnThinCrust.Enabled = false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnThinCrust_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new ThinCrust(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnThinCrust.Enabled = false;
            btnHandTossed.Enabled = false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnTPaneer_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new Paneer(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnTPaneer.Enabled= false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnTTomato_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new FreshTomato(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnTTomato.Enabled=false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnTBBQ_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new Barbeque(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            btnTBBQ.Enabled = false;
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnSizeL_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new SizeLarge(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            setStateSize(false);
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnSizeM_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new SizeMedium(pizzas[Product.ID]);
            Pizza pizza = pizzas[Product.ID];
            //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            setStateSize(false);
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }

        private void BtnSizeS_Click(object sender, EventArgs e)
        {
            pizzas[Product.ID] = new SizeSmall(pizzas[Product.ID]);
            Pizza pizza=pizzas[Product.ID];
          //  MessageBox.Show(pizza.Description);
            SetListViewValue($"{pizza.Description}+{pizza.Price}+1", listView1.SelectedItems[0]);
            setStateSize(false);
            LQty.Text = $"Qty: {drinks.Count + pizzas.Count}";
            LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
        }
        private void setStateCrust(bool thincrust,bool handtossed,bool hotdog,bool cheese)
        {
            btnThinCrust.Enabled= thincrust;
            btnHandTossed.Enabled= handtossed;
            btnCrustHotDog.Enabled= hotdog;
            btnCrustCheese.Enabled= cheese;
        }
        private void setStateTopping(bool bbq,bool tamoto,bool paneer)
        {
            btnTBBQ.Enabled = bbq;
            btnTTomato.Enabled = tamoto;
            btnTPaneer.Enabled = paneer;
        }
        private void setStateSize(bool b)
        {
            btnSizeS.Enabled=b;
            btnSizeL.Enabled=b;
            btnSizeM.Enabled=b;
            
        }
        private void SetListViewValue(string data,ListViewItem listViewItem)
        {
            string[] datas = data.Split('+');
            listViewItem.Text=datas[0];
            listViewItem.SubItems[1].Text="$"+datas[1];
            listViewItem.SubItems[2].Text=datas[2];
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            getProduct product = (getProduct)listView1.SelectedItems[0].Tag;
            if (product.Product.Type == 1)
            {
                //MessageBox.Show(drinks[product.ID].Description);
                setStateSize(false);
                setStateTopping(false,false,false);
                setStateCrust(false, false, false, false);
            }
            if(product.Product.Type == 2)
            {
                Product = product;
                //MessageBox.Show(pizzas[product.ID].Description);
                setStateSize(true);
                setStateTopping(true, true, true);
                setStateCrust(true, true, true, true);
            }
        }

        private void OrderForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        void getcategory()
        {
            if(category.Count > 0) category.Clear();
            if(cat.Count > 0) cat.Clear();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * From Category";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cat=int.Parse(reader["Id"].ToString());
                        KryptonButton btn = new KryptonButton();
                        btn.Font = new Font("Poppins", 12, FontStyle.Bold);
                        btn.OverrideDefault.Back.Color1 = Color.FromArgb(250, 252, 252);
                        btn.OverrideDefault.Back.Color2 = Color.FromArgb(250, 252, 252);
                        btn.StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
                        btn.StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);
                        btn.StateCommon.Back.ColorAngle = 45;
                        btn.StateCommon.Border.Color1 = Color.FromArgb(6, 174, 244);
                        btn.StateCommon.Border.Color2 = Color.FromArgb(8, 142, 254);
                        btn.StateCommon.Border.ColorAngle = 45;
                        btn.StateCommon.Border.Rounding = 20;
                        btn.StateCommon.Border.Width = 1;
                        btn.StatePressed.Back.Color1 = Color.FromArgb(20, 145, 198);
                        btn.StatePressed.Back.Color2 = Color.FromArgb(22, 121, 206);
                        btn.StatePressed.Back.ColorAngle = 135;
                        btn.StatePressed.Border.Color1 = Color.FromArgb(20, 145, 198);
                        btn.StatePressed.Border.Rounding = 20;
                        btn.StatePressed.Border.Width = 1;
                        btn.StateTracking.Back.Color1 = Color.FromArgb(8, 142, 254);
                        btn.StateTracking.Back.Color2 = Color.FromArgb(6, 174, 244);
                        btn.StateTracking.Back.ColorAngle = 45;
                        btn.StateTracking.Border.Color1 = Color.FromArgb(20, 145, 198);
                        btn.StateTracking.Border.Rounding = 20;
                        btn.StateTracking.Border.Width = 1;
                        btn.StateCommon.Content.ShortText.Color1 = Color.FromArgb(8, 142, 254);
                        btn.StateCommon.Content.ShortText.Font= new Font("Poppins", 12, FontStyle.Bold);
                        btn.OverrideDefault.Back.ColorAngle = 45;
                        btn.OverrideDefault.Border.Color1 = Color.FromArgb(8, 142, 244);
                        btn.OverrideDefault.Border.Color2 = Color.FromArgb(8, 142, 244);
                        btn.OverrideDefault.Border.Rounding = 20;
                        btn.OverrideDefault.Border.Width = 1;
                        btn.OverrideDefault.Border.ColorAngle = 45;
                        btn.Text = reader["Category_Type"].ToString();
                        btn.Size = new System.Drawing.Size(120, 120);
                        CategoryFlow.Controls.Add(btn);
                        this.Controls.Add(CategoryFlow);
                        btn.Click += btnCategory_Click;
                        btn.Tag = cat;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            try
            {
                KryptonButton b = (KryptonButton)sender;
                int Id =(int) b.Tag;
               // MessageBox.Show($"Category Id={Id}");
                getData(Id);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getData(int Id)
        {
            try
            {
                ProductFlow.Controls.Clear();
                cmd = new SqlCommand();
                cmd.Connection=conn; cmd.CommandText = $"Select * From Product where Cat_id ={Id}";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Button btn = new Button();
                        btn.Font = new Font("Poppins", 12, FontStyle.Bold);
                        btn.ForeColor = Color.FromArgb(204,0,102);
                        btn.BackColor = Color.FromArgb(250, 252, 252);
                        btn.TextAlign = ContentAlignment.BottomCenter;
                        btn.Text = reader["Price"].ToString() +"$\n"+  reader["Name"].ToString();
                        btn.Size = new System.Drawing.Size(120, 120);

                        Image img = CovertImage.convertBytetoImage((byte[])reader["Picture"]);
                        btn.Image = img;
                        btn.Image = ResizeImage(btn.Image, btn.Size);
                        ProductFlow.Controls.Add(btn);
                        this.Controls.Add(CategoryFlow);
                        btn.Click += btnProduct_Click;
                     
             
                        
                            Product item = new Product(
                                )
                            {
                                Id  =int.Parse(reader["Id"].ToString()),
                                Name=reader["Name"].ToString(),
                                Type =int.Parse( reader["Cat_id"].ToString()),
                                Description=reader["Description"].ToString(),
                                Picture=(byte[])reader["Picture"],
                                Price=double.Parse(reader["Price"].ToString())
                            };
                           
                        

                        btn.Tag = item;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int i = 0,j=0;
        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
               
                Button b = (Button)sender;
                Product item =(Product)b.Tag;
                if (item.Type == 1)
                {
                    
                    drinks.Add(new AddInDrinks(item.Description,item.Price,item.Picture) {Id=item.Id,Name=item.Name});

                    string[] lst = { drinks[j].Description,drinks[j].Price.ToString("C"),"1"};
             
                    ListViewItem listViewItem=new ListViewItem(lst);
                    listView1.Items.Add(listViewItem).Tag =new getProduct {Product= new Product(drinks[j]),ID=j };
                    j++;

                }
                if(item.Type == 2)
                {
                   
                    pizzas.Add(new AddInPizza(item.Description, item.Price)
                    {
                        Id=item.Id,
                        Name=item.Name,
                        Price=item.Price,
                    }
                        );
                    string[] lst = { pizzas[i].Description,pizzas[i].Price.ToString("C"), "1" };
               
                    ListViewItem listViewItem = new ListViewItem(lst);
                    listView1.Items.Add(listViewItem).Tag = new getProduct() { Product = new Product(pizzas[i]), ID = i };
                    i++;
                }
                LQty.Text = $"Qty: {drinks.Count+pizzas.Count}";
                LTotal.Text = $"Total: ${drinks.Sum(d => d.Price) + pizzas.Sum(p => p.Price)}";
              
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static Image ResizeImage(Image image, Size size)
        {
            Image img = new Bitmap(image, size);

            return img;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
