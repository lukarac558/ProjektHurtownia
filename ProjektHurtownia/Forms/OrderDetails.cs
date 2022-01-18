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
        private int idProduct;
        private int count =1;
        private double totalCost;
        private Product product;

        public OrderDetails(int idProduct)
        {
            InitializeComponent();
            this.idProduct = idProduct;
            // public Product(int productId, string productName, int typeId, int disciplineId, int unitQuantity, double unitPrice, int providerId)
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
            // public Order(int idOrder, int idProduct, int idUser, int count, DateTime orderDate, double totalCost)
            int newCount = product.UnitQuantity - count;
            DateTime currentTime = DateTime.Now;
            DateTime guaranteeEnd = currentTime.AddDays(DateBase.GetProviderById(product.ProviderId).GuaranteePeriod);
            DateBase.AddNewOrder(new Order(0, idProduct, DateBase.idUser, count, currentTime, guaranteeEnd, totalCost));
            DateBase.UpdateProductCount(idProduct, newCount);
            string message = "Pomyślnie złożono zamówienie. Będzie ono widoczne w liście twoich zamówień wraz z ograniczoną czasowo możliwością anulowania zamówienia.";
            MessageBox.Show(message, "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            SelectionPanel panel = new SelectionPanel();
            Hide();
            panel.ShowDialog();
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
    }
}
