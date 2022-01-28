using ProjektHurtownia.Classes;
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

    public partial class OrderDetails : Form
    {
        private readonly int idProduct;
        private int count =1;
        private double totalCost;
        private readonly Product product;

        public OrderDetails(int idProduct)
        {
            InitializeComponent();
            this.idProduct = idProduct;
            ((TextBox)countUpDown.Controls[1]).MaxLength = 5;
            product = DateBase.GetProduct(idProduct);
            productNameTextBox.Text = product.ProductName;
            typeTextBox.Text = DateBase.GetTypeById(product.TypeId);         
            disciplineTextBox.Text = DateBase.GetDisciplineById(product.DisciplineId);
            providerTextBox.Text = DateBase.GetProviderById(product.ProviderId).ProviderName;
            priceTextBox.Text = product.UnitPrice + " zł";
            guaranteeTextBox.Text = DateBase.GetProviderById(product.ProviderId).GuaranteePeriod.ToString();
            countUpDown.Maximum = product.UnitQuantity;
            totalCostTextBox.Text = product.UnitPrice + " zł";
            totalCost = product.UnitPrice;
        }

        private void button1_Click(object sender, EventArgs e) // złóż zamówienie
        {           
            if (DateBase.cart.ContainsKey(idProduct))
            {
                DateBase.cart[idProduct] = count;
                MessageBox.Show("Produkt był już w koszyku. Nadpisano liczbę produktów.", "Zmiana liczby produktu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DateBase.cart.Add(idProduct, count);
                MessageBox.Show("Pomyślnie dodano nowy produkt do koszyka.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CartPanel cart = new CartPanel();
            Hide();
            cart.ShowDialog();
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(countUpDown.Value);
            totalCost = count * DateBase.GetProduct(idProduct).UnitPrice;
            totalCostTextBox.Text = totalCost + " zł";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionPanel panel = new SelectionPanel();
            Hide();
            panel.ShowDialog();
            Close();
        }

        private void countUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jeśli liczba nie uległa zmianie, wówczas była poprawna.\nLiczbę równą 0 zamieniono na 1.\nZa duża liczbę zamieniono na maksymalną możliwą.\n", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
