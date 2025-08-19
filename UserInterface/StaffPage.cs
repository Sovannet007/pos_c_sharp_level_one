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
    public partial class StaffPage : Form
    {
        public StaffPage()
        {
            InitializeComponent();

            this.CenterToScreen();

            // design order item dgv
            dgvStaff.Columns.Clear();
            dgvStaff.Columns.Add("staff_id", "No");
            dgvStaff.Columns.Add("first_name", "First Name");
            dgvStaff.Columns.Add("last_name", "Last Name");
            dgvStaff.Columns.Add("email", "Email");   
            dgvStaff.Columns.Add("phone", "phone");   
            dgvStaff.Columns.Add("active", "Active");   
            dgvStaff.Columns.Add("store_name", "Store");   
            dgvStaff.Columns.Add("manager_name", "Manager");   

            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //bind combobox data
            BindComboBox.BindData(cboManager, "select staff_id, first_name+' '+last_name as full_name from sales.staffs");
            BindComboBox.BindData(cboStore, "select store_id,store_name from sales.stores");

            LoadData();


        }

        // BrandSerive
        StaffService staffService = new StaffService();
        Staff staff = new Staff();
        public void LoadData()
        {
            dgvStaff.Rows.Clear();
            foreach(Staff staff in staffService.GetStaffs())
            {
                dgvStaff.Rows.Add(staff.staff_id,staff.first_name,staff.last_name,staff.email,staff.phone, staff.active, staff.store_name,staff.manager_name);
            }
            dgvStaff.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFName.Text.Trim() == "" || txtLName.Text.Trim() == "")
            {
                MessageHelper.WarningMessage("Please input staff first name and last name!");
                return;
            }if (txtEmail.Text.Trim()=="")
            {
                MessageHelper.WarningMessage("Please input staff email!");
                return;
            }

            SqlTransactionHelper.transaction = ConnectionHelper.GetConnection().BeginTransaction();
            staff.first_name = txtFName.Text;
            staff.last_name = txtLName.Text;
            staff.email = txtEmail.Text;
            staff.phone = txtPhone.Text;

            // Set active from cboStatus
            staff.active = (cboStatus.SelectedIndex == 0) ? 1 : 0;
            staff.store_id = Convert.ToInt32(cboStore.SelectedValue);
            staff.manager_id = Convert.ToInt32(cboManager.SelectedValue);

            if (btnSave.Text == "Save")
            {
                if (staffService.Insert(staff))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Staff created!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            else
            {
                if (staffService.Update(staff))
                {
                    SqlTransactionHelper.transaction.Commit();
                    MessageHelper.SuccessMessage("Staff updated!");
                }
                else
                {
                    SqlTransactionHelper.transaction.Rollback();
                }
            }

            //refresh data
            LoadData();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

                staff.staff_id = Convert.ToInt16(row.Cells["staff_id"].Value);
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                txtFName.Text = row.Cells["first_name"].Value.ToString();
                txtLName.Text = row.Cells["last_name"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();

                // Assuming cboStatus has two items: "Active" at index 0, "Inactive" at index 1
                int activeValue = Convert.ToInt32(row.Cells["active"].Value);
                cboStatus.SelectedIndex = (activeValue == 1) ? 0 : 1;

                cboManager.Text = row.Cells["manager_name"].Value.ToString();
                cboStore.Text = row.Cells["store_name"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmMessage())
            {
                staffService.Delete(staff);
            }
            LoadData(); 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            txtPhone.Clear(); 
            btnSave.Enabled = true;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtFName.Focus();
        }

        private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name == "active" && e.Value != null)
            {
                int activeValue;
                if (int.TryParse(e.Value.ToString(), out activeValue))
                {
                    e.Value = (activeValue == 1) ? "Active" : "Inactive";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
