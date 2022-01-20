
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(449, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz co chcesz zrobić";
            // 
            // filteringButton
            // 
            this.filteringButton.Location = new System.Drawing.Point(415, 211);
            this.filteringButton.Name = "filteringButton";
            this.filteringButton.Size = new System.Drawing.Size(73, 51);
            this.filteringButton.TabIndex = 1;
            this.filteringButton.Text = "Przejdź do filtrowania";
            this.filteringButton.UseVisualStyleBackColor = true;
            this.filteringButton.Click += new System.EventHandler(this.filteringButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(453, 205);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(76, 63);
            this.addProductButton.TabIndex = 2;
            this.addProductButton.Text = "Dodaj produkt";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // addTDPButton
            // 
            this.addTDPButton.Location = new System.Drawing.Point(559, 205);
            this.addTDPButton.Name = "addTDPButton";
            this.addTDPButton.Size = new System.Drawing.Size(76, 63);
            this.addTDPButton.TabIndex = 3;
            this.addTDPButton.Text = "Dodaj typ, dyscyplinę lub dostawcę";
            this.addTDPButton.UseVisualStyleBackColor = true;
            this.addTDPButton.Click += new System.EventHandler(this.addTDPButton_Click);
            // 
            // searchByNameButton
            // 
            this.searchByNameButton.Location = new System.Drawing.Point(516, 211);
            this.searchByNameButton.Name = "searchByNameButton";
            this.searchByNameButton.Size = new System.Drawing.Size(73, 51);
            this.searchByNameButton.TabIndex = 6;
            this.searchByNameButton.Text = "Szukaj produkty po nazwie";
            this.searchByNameButton.UseVisualStyleBackColor = true;
            this.searchByNameButton.Click += new System.EventHandler(this.searchByNameButton_Click);
            // 
            // previewOrdersButton
            // 
            this.previewOrdersButton.Location = new System.Drawing.Point(619, 211);
            this.previewOrdersButton.Name = "previewOrdersButton";
            this.previewOrdersButton.Size = new System.Drawing.Size(73, 51);
            this.previewOrdersButton.TabIndex = 7;
            this.previewOrdersButton.Text = "Podgląd zamówień";
            this.previewOrdersButton.UseVisualStyleBackColor = true;
            this.previewOrdersButton.Click += new System.EventHandler(this.previewOrdersButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Wyloguj się";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.previewOrdersButton);
            this.Controls.Add(this.searchByNameButton);
            this.Controls.Add(this.addTDPButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.filteringButton);
            this.Controls.Add(this.label1);
            this.Name = "SelectionPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór operacji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filteringButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button addTDPButton;
        private System.Windows.Forms.Button searchByNameButton;
        private System.Windows.Forms.Button previewOrdersButton;
        private System.Windows.Forms.Button button1;
    }
}