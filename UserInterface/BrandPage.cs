using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using POS_LEVEL_01.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_LEVEL_01.UserInterface
{
    public partial class BrandPage : Form
    {
        public BrandPage()
        {
            InitializeComponent();
            dgvBrand.Columns.Clear();
            dgvBrand.Columns.Add("brand_id","Brand No");
            dgvBrand.Columns.Add("brand_name", "Brand Name");
            dgvBrand.ReadOnly = true;
            dgvBrand.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBrand.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBrand.AllowUserToAddRows = false;
            loadData();
        }

        // BrandSerive
        BrandService brandService = new BrandService();
        // Brand Model
        Brand brand = new Brand();

        // function load brand data into DataGridView form brandService 
        private void loadData()
        {
            dgvBrand.Rows.Clear();
            foreach (Brand brand in brandService.GetBrands())
            {
                dgvBrand.Rows.Add(brand.brand_id, brand.brand_name);
            }
            dgvBrand.ClearSelection();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text.Trim() == "")
            {
                MessageHelper.WarningMessage("Please input brand name!");
                return;
            }

            SqlTransactionHelper.transaction = ConnectionHelper.GetConnection().BeginTransaction();
            brand.brand_name = txtBrand.Text;
            if(btnSave.Text == "Save")
            {
                if (brandService.Insert(brand))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Brand created!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            else
            {
                if (brandService.Update(brand))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Brand updated!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            //refresh data
            loadData();
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBrand.Rows[e.RowIndex];

                brand.brand_id = Convert.ToInt16(row.Cells["brand_id"].Value);
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                txtBrand.Text = row.Cells["brand_name"].Value.ToString();
            }
        }

        //function reset controll
        private void ResetControll()
        {
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtBrand.Clear();
            btnSave.Enabled = true;
            txtBrand.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmMessage())
            {
                brandService.Delete(brand);
            }
            loadData() ;
            ResetControll();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtBrand.Clear() ;
            txtBrand.Focus();
            btnSave.Enabled=true;
            btnSave.Text = "Save";
            btnDelete.Enabled= false;
        }
    }
}
