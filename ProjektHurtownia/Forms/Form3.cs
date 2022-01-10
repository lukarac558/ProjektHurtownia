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
    public partial class Form3 : Form
    {
        private List<Product> actualFiltered = new List<Product>();
        public Form3()
        {
            InitializeComponent();
            var typeList = DateBase.GetAllTypes();
            var disciplineList = DateBase.GetAllDisciplines();
            var providerList = DateBase.GetAllProviders();
            foreach (var type in typeList) // dodanie wszystkich typów produktów do listy wyborów
                checkedListBox1.Items.Add(type);
            foreach (var discipline in disciplineList)
                checkedListBox2.Items.Add(discipline);
            foreach (var provider in providerList)
                checkedListBox3.Items.Add(provider);
            string[] sortOptions = { "Sortuj rosnąco", "Sortuj malejąco" };
            comboBox1.Items.AddRange(sortOptions);
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            var selectedTypes = new List<string>();
            var selectedDisciplines = new List<string>();
            var selectedProviders = new List<string>();
            actualFiltered.Clear();

            foreach (object typeChecked in checkedListBox1.CheckedItems)
                selectedTypes.Add(typeChecked.ToString());

            foreach (object disciplineChecked in checkedListBox2.CheckedItems)
                selectedDisciplines.Add(disciplineChecked.ToString());

            foreach (object providerChecked in checkedListBox3.CheckedItems)
                selectedProviders.Add(providerChecked.ToString());

            double minimumPrice = (double)numericUpDown1.Value;
            double maximumPrice = (double)numericUpDown2.Value;

            actualFiltered = DateBase.FilterProducts(selectedTypes, selectedDisciplines, selectedProviders, minimumPrice, maximumPrice);
            dataGridView1.DataSource = actualFiltered.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Cena = o.UnitPrice }).ToList();

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Sortuj rosnąco"))
            {
                var list = DateBase.OrderProductsByPrice(actualFiltered, "ASC");
                dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Cena = o.UnitPrice }).ToList();
            }
            else if(comboBox1.SelectedItem.Equals("Sortuj malejąco"))
            {
                var list = DateBase.OrderProductsByPrice(actualFiltered, "DESC");
                dataGridView1.DataSource = list.Select(o => new { Identyfikator = o.ProductId, Nazwa = o.ProductName, Cena = o.UnitPrice }).ToList();
            }
        }
    }
}
