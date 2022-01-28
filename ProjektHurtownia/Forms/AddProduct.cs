using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia.Forms
{
    public partial class AddProduct : Form
    {
        int productId;
        int typeId;
        int disciplineId;
        int providerId;
        List<Product> productsList = new List<Product>();
        public AddProduct()
        {
            InitializeComponent();
            ((TextBox)countUpDown.Controls[1]).MaxLength = 5;
            ((TextBox)priceUpDown.Controls[1]).MaxLength = 9;
            var typeList = DateBase.GetAllTypes();
            foreach (var type in typeList)
                typeComboBox.Items.Add(type);
            if (typeList.Count > 0)
                typeComboBox.Text = typeList[0];

            var disciplineList = DateBase.GetAllDisciplines();
            foreach (var discipline in disciplineList)
                disciplineComboBox.Items.Add(discipline);
            if (disciplineList.Count > 0)
                disciplineComboBox.Text = disciplineList[0];

            var providerList = DateBase.GetAllProviders();
            foreach (var provider in providerList)
                providerComboBox.Items.Add(provider);
            if (providerList.Count > 0)
                providerComboBox.Text = providerList[0];

            productsList = DateBase.FilterByProductName("");
            productsDataGridView.DataSource = productsList.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();

            productsDataGridView.Columns["Identyfikator"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["Ilość"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn editProductButton = new DataGridViewButtonColumn
            {
                Name = "Edytuj produkt",
                Text = "Edytuj",
                UseColumnTextForButtonValue = true
            };
            int columnIndex = 4;
            productsDataGridView.Columns.Insert(columnIndex, editProductButton);

            DataGridViewButtonColumn deleteProductButton = new DataGridViewButtonColumn
            {
                Name = "Usuń produkt",
                Text = "Usuń",
                UseColumnTextForButtonValue = true
            };
            columnIndex = 5;
            productsDataGridView.Columns.Insert(columnIndex, deleteProductButton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";

            if (typeComboBox.Text == "")
                error += "Najpierw należy dodać typy do bazy, by móc dodać produkt.\n";
            if(disciplineComboBox.Text == "")
                error += "Najpierw należy dodać dyscypliny do bazy, by móc dodać produkt.\n";
            if(providerComboBox.Text == "")
                error += "Najpierw należy dodać dostawców do bazy, by móc dodać produkt.\n";

            Decimal price = priceUpDown.Value;

            string priceString = price.ToString();
            int index = priceString.IndexOf(',');

            int difference = priceString.Length - (index + 1);

            if (difference > 2)
            error += "Cena musi zawierać 2 cyfry po przecinku i nie być większa od 200000,00zł.\n";

            Regex productName = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9_ ]{3,50}$");
         
            if (!productName.IsMatch(productNameTextBox.Text))
                error = "Należy wprowadzić nazwę produktu. Minimalna liczba znaków to 3 a maksymalna 50.\n";

            if(error != "")
                MessageBox.Show(error, "Bład operacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                typeId = DateBase.GetTypeId(typeComboBox.Text);
                disciplineId = DateBase.GetDisciplineId(disciplineComboBox.Text);
                providerId = DateBase.GetProviderId(providerComboBox.Text);

                if (button1.Text == "Dodaj nowy produkt")
                {                
                    DateBase.AddNewProduct(new Product(0, productNameTextBox.Text, typeId, disciplineId, Convert.ToInt32(countUpDown.Value), Convert.ToDouble(priceUpDown.Value), providerId));
                }
                else if (button1.Text == "Edytuj wybrany produkt")
                {
                    DateBase.EditProduct(new Product(productId, productNameTextBox.Text, typeId, disciplineId, Convert.ToInt32(countUpDown.Value), Convert.ToDouble(priceUpDown.Value), providerId));
                    button1.Text = "Dodaj nowy produkt";
                    productNameTextBox.Text = "";
                    countUpDown.Value = 1;
                    priceUpDown.Value = (decimal)0.01;
                }

                productsList.Clear();
                productsList = DateBase.FilterByProductName("");
                productsDataGridView.DataSource = productsList.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == productsDataGridView.Columns["Edytuj produkt"].Index && e.RowIndex >= 0)
            {
                button1.Text = "Edytuj wybrany produkt";
                DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
                productId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                Product product = DateBase.GetProduct(productId);
                productNameTextBox.Text = product.ProductName;
                typeComboBox.Text = DateBase.GetTypeById(product.TypeId);
                disciplineComboBox.Text = DateBase.GetDisciplineById(product.DisciplineId);
                countUpDown.Value = product.UnitQuantity;
                priceUpDown.Value = (decimal)product.UnitPrice;
                providerComboBox.Text = DateBase.GetProviderById(product.ProviderId).ProviderName;
            }
            else if(e.ColumnIndex == productsDataGridView.Columns["Usuń produkt"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
                productId = Int32.Parse(row.Cells["Identyfikator"].Value.ToString());
                DateBase.DeleteProduct(productId);

                productsList.Clear();
                productsList = DateBase.FilterByProductName("");
                productsDataGridView.DataSource = productsList.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Ilość = o.UnitQuantity, Cena = o.UnitPrice + " zł" }).ToList();
            }
        }

        private void countUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void productNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void priceUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void productsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            productsDataGridView.ClearSelection();
        }
    }
}
