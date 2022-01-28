using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjektHurtownia.Classes;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia.Forms
{
    public partial class CartPanel : Form
    {
        private readonly List<OrderPosition> orderPositionList = new List<OrderPosition>();
        double totalCost;

        private void UpdateDataGridView()
        {
            totalCost = 0;
            cartGridView.Rows.Clear();
            orderPositionList.Clear();

            foreach (var item in DateBase.cart)
                orderPositionList.Add(new OrderPosition(item.Key, item.Value));

            foreach (var order in orderPositionList)
            {
                Product p = DateBase.GetProduct(order.IdProduct);
                order.TotalCost = p.UnitPrice * order.Count;
                totalCost += order.TotalCost;
                cartGridView.Rows.Add(p.ProductId, p.ProductName, DateBase.GetProviderById(p.ProviderId).ProviderName, order.Count, order.TotalCost + " zł", "Usuń");
            }

            totalCostTextBox.Text = totalCost + " zł";
        }

        public CartPanel()
        {
            InitializeComponent();
            cartGridView.Columns.Add("Identyfikator", "Identyfikator produktu");
            cartGridView.Columns.Add("Nazwa", "Nazwa produktu");
            cartGridView.Columns.Add("Marka", "Marka");
            cartGridView.Columns.Add("Ilosc", "Ilość");
            cartGridView.Columns.Add("Cena", "Cena całkowita");
            DataGridViewButtonColumn deletePositionButton = new DataGridViewButtonColumn
            {
                Name = "Usuń z koszyka",
                Text = "Usuń"
            };
            int columnIndex = 5;
            deletePositionButton.UseColumnTextForButtonValue = true;
            cartGridView.Columns.Insert(columnIndex, deletePositionButton);

            cartGridView.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cartGridView.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cartGridView.Columns["Ilosc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cartGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UpdateDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void cartGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cartGridView.Columns["Usuń z koszyka"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = cartGridView.Rows[e.RowIndex];
                int productId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());

                DateBase.cart.Remove(productId);
                UpdateDataGridView();
                MessageBox.Show("Usunięto produkt z koszyka.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void makeOrder_Click(object sender, EventArgs e)
        {
            string provider;
            double cost;
            int count, productId, providerId, maxOrderId, PositionId;
            DateTime guaranteeEnd;

            if (DateBase.cart.Count > 0)
            {
                maxOrderId = DateBase.MaxCurrentOrderId();

                if (maxOrderId == -1)
                    maxOrderId = 0;

                for (int i = 0; i < cartGridView.RowCount; i++)
                {
                    DataGridViewRow row = cartGridView.Rows[i];
                    provider = row.Cells["Marka"].Value.ToString();
                    providerId = DateBase.GetProviderId(provider);
                    cost = Double.Parse(row.Cells["Cena"].Value.ToString().Replace(" zł", ""));
                    count = Int32.Parse(row.Cells["Ilosc"].Value.ToString());
                    productId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                    guaranteeEnd = DateTime.Now.AddDays(DateBase.GetProviderById(providerId).GuaranteePeriod);

                    DateBase.AddNewOrderPosition(new OrderPosition(0, cost, count, productId, guaranteeEnd));

                    DateBase.UpdateProductCount(productId, DateBase.GetProduct(productId).UnitQuantity - count);

                    PositionId = DateBase.MaxCurrentOrderPositionId();
                    DateBase.AddNewOrder(new Order(maxOrderId + 1, PositionId, DateBase.idUser, DateTime.Now));
                }

                DateBase.cart.Clear();
                UpdateDataGridView();
                MessageBox.Show("Pomyślnie złożono zamówienie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Koszyk jest pusty. Uzupełnij koszyk przed złożeniem zamówienia.", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cartGridView_SelectionChanged(object sender, EventArgs e)
        {
            cartGridView.ClearSelection();
        }
    }
}
