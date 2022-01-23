
namespace ProjektHurtownia.Forms
{
    partial class SearchByName
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
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.orderASCButton = new System.Windows.Forms.Button();
            this.orderDESCButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(508, 102);
            this.productNameTextBox.MaxLength = 50;
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(122, 20);
            this.productNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(370, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wpisz nazwę produktu, który chcesz wyszukać w bazie";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(145, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(816, 291);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 17;
            this.button1.Text = "Szukaj produkty";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(66, 584);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 44);
            this.button3.TabIndex = 29;
            this.button3.Text = "Wróc do panelu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // orderASCButton
            // 
            this.orderASCButton.Location = new System.Drawing.Point(508, 207);
            this.orderASCButton.Margin = new System.Windows.Forms.Padding(2);
            this.orderASCButton.Name = "orderASCButton";
            this.orderASCButton.Size = new System.Drawing.Size(59, 36);
            this.orderASCButton.TabIndex = 30;
            this.orderASCButton.Text = "Sortuj rosnąco";
            this.orderASCButton.UseVisualStyleBackColor = true;
            this.orderASCButton.Visible = false;
            this.orderASCButton.Click += new System.EventHandler(this.orderASCButton_Click);
            // 
            // orderDESCButton
            // 
            this.orderDESCButton.Location = new System.Drawing.Point(571, 207);
            this.orderDESCButton.Margin = new System.Windows.Forms.Padding(2);
            this.orderDESCButton.Name = "orderDESCButton";
            this.orderDESCButton.Size = new System.Drawing.Size(60, 36);
            this.orderDESCButton.TabIndex = 31;
            this.orderDESCButton.Text = "Sortuj malejąco";
            this.orderDESCButton.UseVisualStyleBackColor = true;
            this.orderDESCButton.Visible = false;
            this.orderDESCButton.Click += new System.EventHandler(this.orderDESCButton_Click);
            // 
            // SearchByName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Controls.Add(this.orderDESCButton);
            this.Controls.Add(this.orderASCButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productNameTextBox);
            this.Name = "SearchByName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtracja po nazwie, sortowanie i niedostępne produkty";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button orderASCButton;
        private System.Windows.Forms.Button orderDESCButton;
    }
}