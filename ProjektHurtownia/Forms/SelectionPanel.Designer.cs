
namespace ProjektHurtownia.Forms
{
    partial class SelectionPanel
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
            this.filteringButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.addTDPButton = new System.Windows.Forms.Button();
            this.searchByNameButton = new System.Windows.Forms.Button();
            this.previewOrdersButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.cartButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz co chcesz zrobić";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filteringButton
            // 
            this.filteringButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.filteringButton.ForeColor = System.Drawing.Color.White;
            this.filteringButton.Location = new System.Drawing.Point(33, 145);
            this.filteringButton.Name = "filteringButton";
            this.filteringButton.Size = new System.Drawing.Size(80, 60);
            this.filteringButton.TabIndex = 1;
            this.filteringButton.Text = "Przejdź do filtrowania";
            this.filteringButton.UseVisualStyleBackColor = false;
            this.filteringButton.Click += new System.EventHandler(this.filteringButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addProductButton.ForeColor = System.Drawing.Color.White;
            this.addProductButton.Location = new System.Drawing.Point(131, 145);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(84, 60);
            this.addProductButton.TabIndex = 2;
            this.addProductButton.Text = "Przejdź do produktów";
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // addTDPButton
            // 
            this.addTDPButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addTDPButton.ForeColor = System.Drawing.Color.White;
            this.addTDPButton.Location = new System.Drawing.Point(233, 145);
            this.addTDPButton.Name = "addTDPButton";
            this.addTDPButton.Size = new System.Drawing.Size(80, 60);
            this.addTDPButton.TabIndex = 3;
            this.addTDPButton.Text = "Przejdź do atrybutów produktu";
            this.addTDPButton.UseVisualStyleBackColor = false;
            this.addTDPButton.Click += new System.EventHandler(this.addTDPButton_Click);
            // 
            // searchByNameButton
            // 
            this.searchByNameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.searchByNameButton.ForeColor = System.Drawing.Color.White;
            this.searchByNameButton.Location = new System.Drawing.Point(131, 145);
            this.searchByNameButton.Name = "searchByNameButton";
            this.searchByNameButton.Size = new System.Drawing.Size(84, 60);
            this.searchByNameButton.TabIndex = 6;
            this.searchByNameButton.Text = "Szukaj produkty po nazwie";
            this.searchByNameButton.UseVisualStyleBackColor = false;
            this.searchByNameButton.Click += new System.EventHandler(this.searchByNameButton_Click);
            // 
            // previewOrdersButton
            // 
            this.previewOrdersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.previewOrdersButton.ForeColor = System.Drawing.Color.White;
            this.previewOrdersButton.Location = new System.Drawing.Point(332, 145);
            this.previewOrdersButton.Name = "previewOrdersButton";
            this.previewOrdersButton.Size = new System.Drawing.Size(78, 60);
            this.previewOrdersButton.TabIndex = 7;
            this.previewOrdersButton.Text = "Podgląd zamówień";
            this.previewOrdersButton.UseVisualStyleBackColor = false;
            this.previewOrdersButton.Click += new System.EventHandler(this.previewOrdersButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Silver;
            this.logoutButton.Location = new System.Drawing.Point(12, 18);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(88, 33);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "Wyloguj się";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // cartButton
            // 
            this.cartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cartButton.ForeColor = System.Drawing.Color.White;
            this.cartButton.Location = new System.Drawing.Point(233, 145);
            this.cartButton.Name = "cartButton";
            this.cartButton.Size = new System.Drawing.Size(80, 60);
            this.cartButton.TabIndex = 9;
            this.cartButton.Text = "Przejdź do koszyka";
            this.cartButton.UseVisualStyleBackColor = false;
            this.cartButton.Click += new System.EventHandler(this.cartButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 100);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.logoutButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(0, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 69);
            this.panel2.TabIndex = 11;
            // 
            // SelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(440, 309);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addTDPButton);
            this.Controls.Add(this.filteringButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cartButton);
            this.Controls.Add(this.previewOrdersButton);
            this.Controls.Add(this.searchByNameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór operacji";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filteringButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button addTDPButton;
        private System.Windows.Forms.Button searchByNameButton;
        private System.Windows.Forms.Button previewOrdersButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button cartButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}