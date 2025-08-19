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
                dgvStaff.Rows.Add(staff.staff_id,staff.first_name,staff.last_name,staff.email,staff.phone, staff.active, staff.manager_name,staff.store_name);
            }
            dgvStaff.ClearSelection();
        }
    }
}
