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
    public partial class AddTDP : Form
    {
        private void SetVisible()
        {
            label2.Visible = false;
            addTypeButton.Visible = false;
            addDisciplineButton.Visible = false;
            addProviderButton.Visible = false;
            label1.Visible = true;
            label3.Visible = true;
            addButton.Visible = true;
            textBox1.Visible = true;
            comboBox1.Visible = true;
        }

        public AddTDP() // add new type, discipline or provider to database (firsly user have to choose what want to add, then check if name doesn't exist in database)
        {
            InitializeComponent();
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            addButton.Visible = false;
            textBox1.Visible = false;
            numericUpDown1.Visible = false;
            comboBox1.Visible = false;

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex universal = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{3,50}$");

            if (!universal.IsMatch(textBox1.Text) || textBox1.Text != "")
            {
                switch (label1.Text)
                {
                    case "Podaj typ":
                        DateBase.AddNewType(textBox1.Text);
                        break;
                    case "Podaj dyscyplinę":
                        DateBase.AddNewDiscipline(textBox1.Text);
                        break;
                    case "Podaj dostawcę":
                        DateBase.AddNewProvider(textBox1.Text, Convert.ToInt32(numericUpDown1.Value));
                        break;
                }
            }
            else
                MessageBox.Show("Nie można wprowadzić pustego ciągu liter. Minimalna długość to 3, a maksymalna 50 znaków.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void addTypeButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label1.Text = "Podaj typ";
            var typeList = DateBase.GetAllTypes();
            foreach (var type in typeList)
                comboBox1.Items.Add(type);
        }

        private void addDisciplineButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label1.Text = "Podaj dyscyplinę";
            var disciplineList = DateBase.GetAllDisciplines();
            foreach (var discipline in disciplineList)
                comboBox1.Items.Add(discipline);
        }

        private void addProviderButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label4.Visible = true;
            numericUpDown1.Visible = true;
            label1.Text = "Podaj dostawcę";
            var providerList = DateBase.GetAllProviders();
            foreach (var provider in providerList)
                comboBox1.Items.Add(provider);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }
    }
}
