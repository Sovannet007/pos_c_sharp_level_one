using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using POS_LEVEL_01.Service;
using POS_LEVEL_01.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_LEVEL_01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtUsername.Focus(); 
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "") 
            {
                MessageHelper.WarningMessage("Please fill username!");
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageHelper.WarningMessage("Please fill password!");
                return;
            }
             
            User userModel = new User();
            userModel.username = txtUsername.Text;
            userModel.password = txtPassword.Text;

            if (UserService.Login(userModel))
            {
                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();
            }
            else
            {
                MessageHelper.ErrorMessage("Invalid username or password!");
            }

        }
    }
}
