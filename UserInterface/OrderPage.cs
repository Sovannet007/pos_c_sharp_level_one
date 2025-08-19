using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using POS_LEVEL_01.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_LEVEL_01.UserInterface
{
    public partial class OrderPage : Form
    {
        public OrderPage()
        {
            InitializeComponent();
            this.CenterToScreen();

            // design order item dgv
            dgvOrderItem.Columns.Clear();
            dgvOrderItem.Columns.Add("PRODUCT_ID","NO");
            dgvOrderItem.Columns.Add("PRODUCT_NAME","Name"); 
            DataGridViewTextBoxColumn txtQty = new DataGridViewTextBoxColumn();
            txtQty.HeaderText = "Quantity";
            txtQty.Name = "QUANTITY";
            dgvOrderItem.Columns.Add(txtQty);
            DataGridViewTextBoxColumn txtDiscount = new DataGridViewTextBoxColumn();
            txtDiscount.HeaderText = "Discount";
            txtDiscount.Name = "DISCOUNT";
            dgvOrderItem.Columns.Add(txtDiscount);
            dgvOrderItem.Columns.Add("TOTAL","Sub Total");



            dgvOrderItem.AllowUserToAddRows = false;
            dgvOrderItem.RowHeadersVisible = false;
            dgvOrderItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            //bind combobox data
            BindComboBox.BindData(cboCustomer, "select customer_id, first_name+' '+last_name as full_name from sales.customers");
            BindComboBox.BindData(cboStore, "select store_id,store_name from sales.stores");

            //load brand , category and product
            LoadBrand();
            LoadCategory();
            LoadProduct();
        }

        BrandService brandService = new BrandService();
        CategoryServie categoryServie = new CategoryServie();
        ProductService productService = new ProductService();
        private void LoadBrand()
        {
            foreach (Brand brand in brandService.GetBrands()) { 
                Button button = new Button(); 
                button.Name = brand.brand_id.ToString();
                button.Text = brand.brand_name.ToString();
                button.Height = 33;
                flpBrand.Controls.Add(button);
            }
            flpBrand.FlowDirection = FlowDirection.LeftToRight;
            flpBrand.AutoScroll = true;
        }
        
        private void LoadCategory()
        {
            foreach (Category category in categoryServie.GetCategories()) { 
                Button button = new Button(); 
                button.Name = category.category_id.ToString();
                button.Text = category.category_name.ToString(); 
                button.Height = 33;
                flpCategory.Controls.Add(button);
            }
            flpCategory.FlowDirection = FlowDirection.LeftToRight;
            flpCategory.AutoScroll = true;
        }

        private void LoadProduct() {
            foreach (Product product in productService.GetProducts()) { 
                Button btn = new Button();
                btn.Name = product.product_id.ToString();
                btn.Text = product.product_name.ToString();
                btn.Height = 100;
                btn.Width = 150;
                flpShowProduct.Controls.Add(btn);
            }

            flpShowProduct.FlowDirection = FlowDirection.LeftToRight;
            flpShowProduct.AutoScroll = true;
        }
    }
}
