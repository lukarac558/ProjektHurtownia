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
            if(DateBase.permission.Equals("Customer"))
            {
                addProductButton.Visible = false;
                addTDPButton.Visible = false;
            }
            else if (DateBase.permission.Equals("Admin"))
            {
                filteringButton.Visible = false;
                searchByNameButton.Visible = false;
                previewOrdersButton.Visible = false;               
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            Hide();
            add.ShowDialog();
            Close();
        }
        private void addTDPButton_Click(object sender, EventArgs e)
        {
            AddTDP tdp = new AddTDP();
            Hide();
            tdp.ShowDialog();
            Close();
        }

        private void filteringButton_Click(object sender, EventArgs e)
        {
            Filtering filtruj = new Filtering();
            Hide();
            filtruj.ShowDialog();
            Close();
        }
       
        private void searchByNameButton_Click(object sender, EventArgs e)
        {
            SearchByName search = new SearchByName();
            Hide();
            search.ShowDialog();
            Close();
        }

        private void previewOrdersButton_Click(object sender, EventArgs e)
        {
            CurrentOrders orders = new CurrentOrders();
            Hide();
            orders.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateBase.LogOut();
            StartPage start = new StartPage();
            Hide();
            start.ShowDialog();
            Close();
        }
    }
}
