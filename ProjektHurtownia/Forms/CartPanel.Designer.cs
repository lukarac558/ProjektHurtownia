
namespace ProjektHurtownia.Forms
{
    partial class CartPanel
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
            this.cartGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.makeOrder = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.totalCostTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cartGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cartGridView
            // 
            this.cartGridView.AllowUserToAddRows = false;
            this.cartGridView.AllowUserToDeleteRows = false;
            this.cartGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartGridView.Location = new System.Drawing.Point(278, 139);
            this.cartGridView.Name = "cartGridView";
            this.cartGridView.ReadOnly = true;
            this.cartGridView.Size = new System.Drawing.Size(660, 320);
            this.cartGridView.TabIndex = 0;
            this.cartGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cartGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(556, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twój koszyk";
            // 
            // makeOrder
            // 
            this.makeOrder.Location = new System.Drawing.Point(542, 531);
            this.makeOrder.Name = "makeOrder";
            this.makeOrder.Size = new System.Drawing.Size(136, 44);
            this.makeOrder.TabIndex = 2;
            this.makeOrder.Text = "Złóż zamówienie";
            this.makeOrder.UseVisualStyleBackColor = true;
            this.makeOrder.Click += new System.EventHandler(this.makeOrder_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(108, 566);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 44);
            this.button3.TabIndex = 30;
            this.button3.Text = "Wróc do panelu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // totalCostTextBox
            // 
            this.totalCostTextBox.Location = new System.Drawing.Point(560, 481);
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.ReadOnly = true;
            this.totalCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalCostTextBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Obecny koszt zamówienia";
            // 
            // CartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalCostTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.makeOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cartGridView);
            this.Name = "CartPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cart";
            ((System.ComponentModel.ISupportInitialize)(this.cartGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cartGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button makeOrder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox totalCostTextBox;
        private System.Windows.Forms.Label label2;
    }
}