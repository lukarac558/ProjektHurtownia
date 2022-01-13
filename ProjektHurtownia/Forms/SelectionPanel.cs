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
    public partial class SelectionPanel : Form
    {
        public SelectionPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filtering filtruj = new Filtering();
            Hide();
            filtruj.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            Hide();
            add.ShowDialog();
            Close();
        }
    }
}
