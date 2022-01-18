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
        private List<Product> actualSearched= new List<Product>();
        private bool ifInsertSearch = false;
        private bool ifInsertNotAvailable = false;
        private int index = 4;

        private void AddOrderButton(string name, string text, int index)
        {
            DataGridViewButtonColumn makeOrderButton = new DataGridViewButtonColumn();
            makeOrderButton.Name = name;
            makeOrderButton.Text = text;
            int columnIndex = index;
            makeOrderButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(columnIndex, makeOrderButton);
            dataGridView1.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["IlośćJednostkowa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["CenaJednostkowa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public SearchByName()
        {
            InitializeComponent();
            string[] sortOptions = { "Sortuj rosnąco", "Sortuj malejąco" };
            comboBox1.Items.AddRange(sortOptions);                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = productNameTextBox.Text;
            actualSearched.Clear();
            actualSearched = DateBase.FilterByProductName(name);
            dataGridView1.DataSource = actualSearched.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, IlośćJednostkowa = o.UnitQuantity, CenaJednostkowa = o.UnitPrice + " zł" }).ToList();

            if (!ifInsertSearch)
            {
                AddOrderButton("Zamów teraz", "Złóż zamówienie", index);
                index++;
                ifInsertSearch = true;
            }

            if (ifInsertNotAvailable)
            {
                dataGridView1.Columns["Czy uzupełnić?"].Visible = false;
                dataGridView1.Columns["Zamów teraz"].Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualSearched.Clear();
            actualSearched = DateBase.SearchNotAvailableProducts();
            dataGridView1.DataSource = actualSearched.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, IlośćJednostkowa = o.UnitQuantity, CenaJednostkowa = o.UnitPrice + " zł" }).ToList();
            if (!ifInsertNotAvailable)
            {
                AddOrderButton("Czy uzupełnić?", "Zapytaj o produkt", index);
                index++;
                ifInsertNotAvailable = true;
            }
          
            if(ifInsertSearch)
            {
                dataGridView1.Columns["Czy uzupełnić?"].Visible = true;
                dataGridView1.Columns["Zamów teraz"].Visible = false;
            }                        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualSearched.Count == 0)
                MessageBox.Show("Brak produktów do sortowania", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (comboBox1.SelectedItem.Equals("Sortuj rosnąco"))
                {
                    var list = DateBase.OrderProductsByPrice(actualSearched, "ASC");
                    dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, IlośćJednostkowa = o.UnitQuantity, CenaJednostkowa = o.UnitPrice + " zł" }).ToList();
                }
                else if (comboBox1.SelectedItem.Equals("Sortuj malejąco"))
                {
                    var list = DateBase.OrderProductsByPrice(actualSearched, "DESC");
                    dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, IlośćJednostkowa = o.UnitQuantity, CenaJednostkowa = o.UnitPrice + " zł" }).ToList();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ifInsertSearch && e.ColumnIndex == dataGridView1.Columns["Zamów teraz"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                OrderDetails order = new OrderDetails(id);
                Hide();
                order.ShowDialog();
                Close();
                // przenosi do nowego formularza, gdzie użytkownik wybiera ilość i składa zamówienie
            }
            else if (ifInsertNotAvailable && e.ColumnIndex == dataGridView1.Columns["Czy uzupełnić?"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("Dziękujemy za przekazanie informacji. Wkrótce postaramy się uzupełnić zapasy.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }
    }
}
