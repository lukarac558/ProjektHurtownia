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
    public partial class SearchByName : Form
    {
        private List<Product> actualSearched = new List<Product>();

        void AddProviderColumn()
        {
            DataGridViewColumn provider = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            provider.CellTemplate = cell;
            provider.Name = "Marka";
            int columnIndex = 4;
            dataGridView1.Columns.Insert(columnIndex, provider);
            DataGridViewRow row;

            for (int i = 0; i < actualSearched.Count; i++)
            {
                row = dataGridView1.Rows[i];
                int productId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                Product product = DateBase.GetProduct(productId);
                dataGridView1.Rows[i].Cells[4].Value = DateBase.GetProviderById(product.ProviderId).ProviderName;
            }
        }

        private void AddOrderButtonColumn()
        {
            DataGridViewButtonColumn makeOrderButton = new DataGridViewButtonColumn
            {
                Name = "Dodaj do koszyka",
                Text = "Wybierz"
            };
            int columnIndex = 5;
            makeOrderButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(columnIndex, makeOrderButton);
        }

        private void ChangeColumnsAlignment()
        {
            dataGridView1.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Ilość"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public SearchByName()
        {
            InitializeComponent();             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            actualSearched.Clear();
            string name = productNameTextBox.Text;
            actualSearched = DateBase.FilterByProductName(name);
            dataGridView1.DataSource = actualSearched.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();

            AddProviderColumn();
            AddOrderButtonColumn();
            ChangeColumnsAlignment();

            if (actualSearched.Count == 0)
            {
                orderASCButton.Visible = false;
                orderDESCButton.Visible = false;
                MessageBox.Show("Nie zwrócono żadnych wyników. Zmień filtry.", "Brak wyszukań", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                orderASCButton.Visible = true;
                orderDESCButton.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){ }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Dodaj do koszyka"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int count = Int32.Parse(row.Cells["Ilość"].Value.ToString());
                if (count > 0)
                {
                    int id = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                    OrderDetails order = new OrderDetails(id);
                    Hide();
                    order.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show("Brak dostępnych egzemplarzy. Niemożliwe dodanie do koszyka.", "Brak produktu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void orderASCButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            var list = DateBase.OrderProductsByPrice(actualSearched, "ASC");
            dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();
            AddProviderColumn();
            AddOrderButtonColumn();
            ChangeColumnsAlignment();
        }

        private void orderDESCButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            var list = DateBase.OrderProductsByPrice(actualSearched, "DESC");
            dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();
            AddProviderColumn();
            AddOrderButtonColumn();
            ChangeColumnsAlignment();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
