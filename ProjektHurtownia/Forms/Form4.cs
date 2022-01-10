using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia.Forms
{  

    public partial class Form4 : Form
    {
        private int idProduct;

        public Form4(int idProduct)
        {
            InitializeComponent();
            this.idProduct = idProduct;
        }

        private void button1_Click(object sender, EventArgs e) // złóż zamówienie
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
