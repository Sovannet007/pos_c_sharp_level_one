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
    public partial class CategoryPage : Form
    {
        public CategoryPage()
        {
            InitializeComponent();

            dgvCategory.Columns.Clear();
            dgvCategory.Columns.Add("category_id", "Category No");
            dgvCategory.Columns.Add("category_name", "Category Name");
            dgvCategory.ReadOnly = true;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCategory.AllowUserToAddRows = false;
            loadData();
        }

        // CategoryService
        CategoryServie categoryService = new CategoryServie();
        // Brand Model
        Category category = new Category();

        // function load category data into DataGridView form categoryService 
        private void loadData()
        {
            dgvCategory.Rows.Clear();
            foreach (Category category in categoryService.GetCategories())
            {
                dgvCategory.Rows.Add(category.category_id, category.category_name);
            }
            dgvCategory.ClearSelection();
        }
   
        //function reset controll
        private void ResetControll()
        {
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtCategory.Clear();
            btnSave.Enabled = true;
            txtCategory.Focus();
        } 

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtCategory.Clear();
            txtCategory.Focus();
            btnSave.Enabled = true;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim() == "")
            {
                MessageHelper.WarningMessage("Please input brand name!");
                return;
            }

            SqlTransactionHelper.transaction = ConnectionHelper.GetConnection().BeginTransaction();
            category.category_name = txtCategory.Text;
            if (btnSave.Text == "Save")
            {
                if (categoryService.Insert(category))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Category created!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            else
            {
                if (categoryService.Update(category))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Category updated!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            //refresh data
            loadData();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];

                category.category_id = Convert.ToInt16(row.Cells["category_id"].Value);
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                txtCategory.Text = row.Cells["category_name"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmMessage())
            {
                categoryService.Delete(category);
            }
            loadData();
            ResetControll();
        }
    }
}
