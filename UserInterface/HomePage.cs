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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrandPage brandPage = new BrandPage();
            brandPage.ShowDialog();
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OrderPage orderPage = new OrderPage();
            orderPage.ShowDialog();
        }

        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryPage categoryPage = new CategoryPage();
            categoryPage.ShowDialog();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffPage staffPage = new StaffPage();
            staffPage.ShowDialog();
        }
    }
}
