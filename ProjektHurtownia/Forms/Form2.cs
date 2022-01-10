using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektHurtownia.Forms;

namespace ProjektHurtownia
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // this.dataGridView1.AutoGenerateColumns = false; // w designerze
            var list = DateBase.SearchAvailableProducts();
            dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Cena = o.UnitPrice }).ToList();
            DataGridViewButtonColumn makeOrderButton = new DataGridViewButtonColumn();
            makeOrderButton.Name = "makeOrder";
            makeOrderButton.Text = "Zloz zamowienie";
            int columnIndex = 3;
            makeOrderButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(columnIndex, makeOrderButton);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["makeOrder"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                Form4 zamowienie = new Form4(id);
                Hide();
                zamowienie.ShowDialog();
                Close();
                // przenosi do nowego formularza, gdzie użytkownik wybiera ilość i składa zamówienie
            }
        }
    }
}
