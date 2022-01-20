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
        public AddProduct()
        {
            InitializeComponent();
            var typeList = DateBase.GetAllTypes();
            foreach (var type in typeList)
                typeComboBox.Items.Add(type);
            var disciplineList = DateBase.GetAllDisciplines();
            foreach (var discipline in disciplineList)
                disciplineComboBox.Items.Add(discipline);
            var providerList = DateBase.GetAllProviders();
            foreach (var provider in providerList)
                providerComboBox.Items.Add(provider);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex productName = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ_ -]{3,50}$");

            string error = "";

            if (!productName.IsMatch(productNameTextBox.Text))
                error = "Należy wprowadzić nazwę produktu. Minimalna liczba znaków to 3 a maksymalna 50.";

            if(error != "")
                MessageBox.Show(error, "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int typeId, disciplineId, providerId;
                typeId = DateBase.GetTypeId(typeComboBox.Text);
                disciplineId = DateBase.GetDisciplineId(disciplineComboBox.Text);
                providerId = DateBase.GetProviderId(providerComboBox.Text);

                DateBase.AddNewProduct(new Product(0, productNameTextBox.Text, typeId, disciplineId, Convert.ToInt32(countUpDown.Value), Convert.ToDouble(priceUpDown.Value), providerId));

                MessageBox.Show("Poprawnie dodano produkt do bazy. Nastąpi powrót do panelu wyboru.");

                SelectionPanel welcome = new SelectionPanel();
                Hide();
                welcome.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void checkTypesButton_Click(object sender, EventArgs e)
        {

        }

        private void checkDisciplineButton_Click(object sender, EventArgs e)
        {

        }

        private void checkProviderButton_Click(object sender, EventArgs e)
        {

        }
    }
}
