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

        private void AddToDataGridView()
        {
            currentOrders = DateBase.GetUserOrders();
            dataGridView1.Rows.Clear();
            foreach (var order in currentOrders)
            {
                Product p = DateBase.GetProduct(order.IdProduct);
                dataGridView1.Rows.Add(order.IdOrder, p.ProductName, DateBase.GetProviderById(p.ProviderId).ProviderName, order.TotalCost + " zł", order.Count, order.OrderDate, order.GuaranteeEnd, "Anuluj");
            }
        }

        public CurrentOrders() // dodać opcję zwrotu zawówionych produktów(jeśli nie minął termin zwrotu)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Identyfikator", "Identyfikator zamówienia");
            dataGridView1.Columns.Add("Nazwa", "Nazwa produktu");
            dataGridView1.Columns.Add("Marka", "Marka");
            dataGridView1.Columns.Add("Cena", "Cena całkowita");
            dataGridView1.Columns.Add("Ilosc", "Ilość");
            dataGridView1.Columns.Add("DataZamowienia", "Data zamówienia");
            dataGridView1.Columns.Add("KoniecGwarancji", "Data końca gwarancji");
            DataGridViewButtonColumn cancelOrderButton = new DataGridViewButtonColumn();
            cancelOrderButton.Name = "Zwróć zamówienie";
            cancelOrderButton.Text = "Zwróć";
            int columnIndex = 7;
            cancelOrderButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(columnIndex, cancelOrderButton);

            dataGridView1.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Ilosc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddToDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex == dataGridView1.Columns["Zwróć zamówienie"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int orderId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());             
                Order order = currentOrders.Find(x => x.IdOrder == orderId);                    
                int newCount = DateBase.GetProduct(order.IdProduct).UnitQuantity + order.Count;

                DateBase.CancelOrder(orderId, order.IdProduct, newCount);
                
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
    }
}
