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
    public partial class CurrentOrders : Form
    {
        private List<Order> currentOrders = new List<Order>();
        private List<OrderPosition> orderPositions = new List<OrderPosition>();

        private void ChangeColumnsAlignment()
        {
            dataGridView1.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Pozycja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Ilosc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddToDataGridView()
        {
            currentOrders = DateBase.GetUserOrders();
            orderPositions.Clear();
            dataGridView1.Rows.Clear();

            foreach (var order in currentOrders)
            {
                orderPositions = DateBase.GetOrderPositions(order.IdOrder);

                foreach (var position in orderPositions)
                {
                    Product p = DateBase.GetProduct(position.IdProduct);
                    dataGridView1.Rows.Add(order.IdOrder, position.IdOrderPosition, p.ProductName, DateBase.GetProviderById(p.ProviderId).ProviderName,
                        position.TotalCost + " zł", position.Count, order.OrderDate, position.GuaranteeEnd, "Anuluj");
                }
            }
            ChangeColumnsAlignment();
        }
      
        public CurrentOrders() // dodać opcję zwrotu zawówionych produktów(jeśli nie minął termin zwrotu)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Identyfikator", "Identyfikator zamówienia");
            dataGridView1.Columns.Add("Pozycja", "Pozycja zamówienia");
            dataGridView1.Columns.Add("Nazwa", "Nazwa produktu");
            dataGridView1.Columns.Add("Marka", "Marka");
            dataGridView1.Columns.Add("Cena", "Cena całkowita");
            dataGridView1.Columns.Add("Ilosc", "Ilość");
            dataGridView1.Columns.Add("DataZamowienia", "Data zamówienia");
            dataGridView1.Columns.Add("KoniecGwarancji", "Data końca gwarancji");
            DataGridViewButtonColumn cancelOrderButton = new DataGridViewButtonColumn
            {
                Name = "Zwróć zamówienie",
                Text = "Zwróć"
            };
            int columnIndex = 8;
            cancelOrderButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(columnIndex, cancelOrderButton);         

            AddToDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex == dataGridView1.Columns["Zwróć zamówienie"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int orderPositionId = Int32.Parse(row.Cells["Pozycja"].Value.ToString());
                OrderPosition orderPosition = DateBase.GetOrderPosition(orderPositionId);
                int orderId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());

                int newCount = DateBase.GetProduct(orderPosition.IdProduct).UnitQuantity + orderPosition.Count;
                DateBase.ReturnOrderPosition(orderPositionId, orderPosition.IdProduct, newCount);

                DateBase.DeleteOrder(orderId); // Jeśli usunięto wszystkie pozycje zamówienia, usunięte zostanie również zamówienie. 

                AddToDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
