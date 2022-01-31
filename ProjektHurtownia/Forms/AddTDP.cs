using ProjektHurtownia.Classes;
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
        List<string> stringList = new List<string>();
        string name;

        private void SetVisible()
        {
            label2.Visible = false;
            addTypeButton.Visible = false;
            addDisciplineButton.Visible = false;
            addProviderButton.Visible = false;
            label1.Visible = true;
            addButton.Visible = true;
            textBox1.Visible = true;
            dataGridView1.Visible = true;
        }

        private void PrepareGridView()
        {
            switch (label1.Text)
            {
                case "Podaj typ":
                    stringList = DateBase.GetAllTypes();
                    break;
                case "Podaj dyscyplinę":
                    stringList = DateBase.GetAllDisciplines();
                    break;
                case "Podaj dostawcę":
                    stringList = DateBase.GetAllProviders();
                    break;
            }

            dataGridView1.DataSource = stringList.Select(x => new { Nazwa = x }).ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddButons()
        {
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
            {
                Name = "Edytuj",
                Text = "Przejdź do edycji",
                UseColumnTextForButtonValue = true
            };
            int columnIndex = 1;
            dataGridView1.Columns.Insert(columnIndex, editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = "Usuń",
                Text = "Usuń",
                UseColumnTextForButtonValue = true
            };
            columnIndex = 2;
            dataGridView1.Columns.Insert(columnIndex, deleteButton);
        }

        public AddTDP() // add new type, discipline or provider to database (firsly user have to choose what want to add, then check if name doesn't exist in database)
        {
            InitializeComponent();
            ((TextBox)numericUpDown1.Controls[1]).MaxLength = 4;
            label1.Visible = false;
            label4.Visible = false;
            addButton.Visible = false;
            textBox1.Visible = false;
            numericUpDown1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex universal = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9_ ]{3,50}$"); 

            if (universal.IsMatch(textBox1.Text)) 
            {
                switch (addButton.Text)
                {
                    case "Dodaj":
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
                        break;

                    case "Edytuj typ":
                        DateBase.EditType(name, textBox1.Text);
                        break;

                    case "Edytuj dyscyplinę":
                        DateBase.EditDiscipline(name, textBox1.Text);
                        break;

                    case "Edytuj dostawcę":
                        DateBase.EditProvider(name, new Provider(0, textBox1.Text, (short)numericUpDown1.Value));
                        break;
                }
                PrepareGridView();
                textBox1.Text = "";
                numericUpDown1.Value = 0;
            }      
            else
                MessageBox.Show("Minimalna długość to 3 a maksymalna 50 liter.\n", "Niepoprawna długość", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
        }

        private void addTypeButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label1.Text = "Podaj typ";
            PrepareGridView();
            AddButons();
        }

        private void addDisciplineButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label1.Text = "Podaj dyscyplinę";
            PrepareGridView();
            AddButons();
        }

        private void addProviderButton_Click(object sender, EventArgs e)
        {
            SetVisible();
            label1.Text = "Podaj dostawcę";
            PrepareGridView();
            AddButons();
            label4.Visible = true;
            numericUpDown1.Visible = true;          
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            SelectionPanel welcome = new SelectionPanel();
            Hide();
            welcome.ShowDialog();
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edytuj"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                name = row.Cells["Nazwa"].Value.ToString();

                textBox1.Text = name;

                switch (label1.Text)
                {
                    case "Podaj typ":
                        addButton.Text = "Edytuj typ";
                        break;
                    case "Podaj dyscyplinę":
                        addButton.Text = "Edytuj dyscyplinę";
                        break;
                    case "Podaj dostawcę":
                        int providerId = DateBase.GetProviderId(name);
                        numericUpDown1.Value = DateBase.GetProviderById(providerId).GuaranteePeriod;
                        addButton.Text = "Edytuj dostawcę";
                        break;
                }

                PrepareGridView();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Usuń"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                name = row.Cells["Nazwa"].Value.ToString();

                switch (label1.Text)
                {
                    case "Podaj typ":
                        DateBase.DeleteType(name);
                        break;
                    case "Podaj dyscyplinę":
                        DateBase.DeleteDiscipline(name);
                        break;
                    case "Podaj dostawcę":
                        DateBase.DeleteProvider(name);
                        break;
                }

                PrepareGridView();
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
