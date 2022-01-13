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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex productName = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{3,50}$");

            string error = "";

            if (!productName.IsMatch(productNameTextBox.Text))
                error = "Należy wprowadzić nazwę produktu. Minimalna liczba znaków to 3 a maksymalna 50.";

            int typeId = DateBase.GetTypeId(typeTextBox.Text);
            if (typeId <= 0)
                error += "Wprowadzony typ nie istnieje jeszcze w bazie.";

            int disciplineId = DateBase.GetDisciplineId(disciplineTextBox.Text);
            if (disciplineId <= 0)
                error += "Wprowadzona dyscyplina nie istnieje jeszcze w bazie.";

            int providereId = DateBase.GetDisciplineId(providerTextBox.Text);
            if (providereId <= 0)
                error += "Wprowadzony dostawca nie istnieje jeszcze w bazie.";

            if(error != "")
                MessageBox.Show(error, "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DateBase.AddNewProduct(new Product(0, productNameTextBox.Text, typeId, disciplineId, Convert.ToInt32(countUpDown.Value), Convert.ToDouble(priceUpDown.Value), providereId));

                MessageBox.Show("Poprawnie dodano produkt do bazy. Nastąpi powrót do panelu wyboru.");

                SelectionPanel welcome = new SelectionPanel();
                Hide();
                welcome.ShowDialog();
                Close();
            }

            /*
            DateBase.AddNewProduct(new Product(0,"Piłka gumowa", 5, 1, 100, 29.99, 13));
            DateBase.AddNewProduct(new Product(0, "Bramka miniaturowa", 4, 1, 50, 239.99, 14));
            DateBase.AddNewProduct(new Product(0, "Piłka UEFA", 5, 1, 10, 120.00, 13));
            DateBase.AddNewProduct(new Product(0, "Rękawice bramkarskie", 6, 1, 10, 119.49, 14));
            DateBase.AddNewProduct(new Product(0, "Piłka do koszykówki", 5, 1, 100, 80.00, 13));
            DateBase.AddNewProduct(new Product(0, "Piłka ALL-STARS", 5, 2, 3, 199.99, 13));
            DateBase.AddNewProduct(new Product(0, "Rękawice narciarskie", 6, 3, 100, 79.99, 14));
            DateBase.AddNewProduct(new Product(0, "Bramka standardowa", 4, 1, 50, 400.00, 14));
            */
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
