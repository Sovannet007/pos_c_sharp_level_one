namespace POS_LEVEL_01.UserInterface
{
    partial class OrderPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.dgvOrderItem = new System.Windows.Forms.DataGridView();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.flpBrand = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAllBrand = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStore = new System.Windows.Forms.ComboBox();
            this.flpShowProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.flpCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAllCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).BeginInit();
            this.flpBrand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flpCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand";
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveOrder.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOrder.Location = new System.Drawing.Point(983, 621);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(131, 46);
            this.btnRemoveOrder.TabIndex = 1;
            this.btnRemoveOrder.Text = "Remove";
            this.btnRemoveOrder.UseVisualStyleBackColor = false;
            // 
            // dgvOrderItem
            // 
            this.dgvOrderItem.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItem.Location = new System.Drawing.Point(825, 159);
            this.dgvOrderItem.Name = "dgvOrderItem";
            this.dgvOrderItem.RowHeadersWidth = 51;
            this.dgvOrderItem.RowTemplate.Height = 24;
            this.dgvOrderItem.Size = new System.Drawing.Size(446, 361);
            this.dgvOrderItem.TabIndex = 2;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Font = new System.Drawing.Font("Myanmar Sans Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(969, 545);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(302, 38);
            this.txtGrandTotal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(821, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer";
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveOrder.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOrder.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSaveOrder.Location = new System.Drawing.Point(825, 621);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(122, 46);
            this.btnSaveOrder.TabIndex = 1;
            this.btnSaveOrder.Text = "Save";
            this.btnSaveOrder.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1157, 621);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 46);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.ItemHeight = 22;
            this.cboCustomer.Location = new System.Drawing.Point(825, 108);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(238, 30);
            this.cboCustomer.TabIndex = 4;
            // 
            // flpBrand
            // 
            this.flpBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBrand.Controls.Add(this.btnAllBrand);
            this.flpBrand.Location = new System.Drawing.Point(12, 108);
            this.flpBrand.Name = "flpBrand";
            this.flpBrand.Size = new System.Drawing.Size(341, 42);
            this.flpBrand.TabIndex = 0;
            // 
            // btnAllBrand
            // 
            this.btnAllBrand.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllBrand.Location = new System.Drawing.Point(3, 3);
            this.btnAllBrand.Name = "btnAllBrand";
            this.btnAllBrand.Size = new System.Drawing.Size(47, 33);
            this.btnAllBrand.TabIndex = 6;
            this.btnAllBrand.Text = "All";
            this.btnAllBrand.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1064, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Store";
            // 
            // cboStore
            // 
            this.cboStore.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStore.FormattingEnabled = true;
            this.cboStore.ItemHeight = 22;
            this.cboStore.Location = new System.Drawing.Point(1069, 108);
            this.cboStore.Name = "cboStore";
            this.cboStore.Size = new System.Drawing.Size(202, 30);
            this.cboStore.TabIndex = 4;
            // 
            // flpShowProduct
            // 
            this.flpShowProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpShowProduct.Location = new System.Drawing.Point(12, 159);
            this.flpShowProduct.Name = "flpShowProduct";
            this.flpShowProduct.Size = new System.Drawing.Size(805, 522);
            this.flpShowProduct.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Sans Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(823, 548);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grand Total";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 59);
            this.panel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(448, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "Point Of Sale Form";
            // 
            // flpCategory
            // 
            this.flpCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCategory.Controls.Add(this.btnAllCategory);
            this.flpCategory.Location = new System.Drawing.Point(377, 108);
            this.flpCategory.Name = "flpCategory";
            this.flpCategory.Size = new System.Drawing.Size(440, 42);
            this.flpCategory.TabIndex = 0;
            // 
            // btnAllCategory
            // 
            this.btnAllCategory.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllCategory.Location = new System.Drawing.Point(3, 3);
            this.btnAllCategory.Name = "btnAllCategory";
            this.btnAllCategory.Size = new System.Drawing.Size(55, 33);
            this.btnAllCategory.TabIndex = 6;
            this.btnAllCategory.Text = "All";
            this.btnAllCategory.UseVisualStyleBackColor = true;
            // 
            // OrderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 693);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboStore);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpShowProduct);
            this.Controls.Add(this.flpCategory);
            this.Controls.Add(this.flpBrand);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnRemoveOrder);
            this.Controls.Add(this.dgvOrderItem);
            this.Font = new System.Drawing.Font("Myanmar Sans Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderPage";
            this.Text = "OrderPage";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).EndInit();
            this.flpBrand.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flpCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveOrder;
        private System.Windows.Forms.DataGridView dgvOrderItem;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.FlowLayoutPanel flpBrand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStore;
        private System.Windows.Forms.FlowLayoutPanel flpShowProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAllBrand;
        private System.Windows.Forms.FlowLayoutPanel flpCategory;
        private System.Windows.Forms.Button btnAllCategory;
    }
}