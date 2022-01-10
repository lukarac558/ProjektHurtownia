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
        public Form3()
        {
            InitializeComponent();
            List<string> typeList = DateBase.GetAllTypes();
            List<string> disciplineList = DateBase.GetAllDisciplines();
            List<string> providerList = DateBase.GetAllProviders();
            foreach (var type in typeList) // dodanie wszystkich typów produktów do listy wyborów
                checkedListBox1.Items.Add(type);
            foreach (var discipline in disciplineList)
                checkedListBox2.Items.Add(discipline);
            foreach (var provider in providerList)
                checkedListBox3.Items.Add(provider);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedTypes = new List<string>();
            List<string> selectedDisciplines = new List<string>();
            List<string> selectedProviders = new List<string>();

            foreach (object typeChecked in checkedListBox1.CheckedItems)
                selectedTypes.Add(typeChecked.ToString());

            foreach (object disciplineChecked in checkedListBox2.CheckedItems)
                selectedTypes.Add(disciplineChecked.ToString());

            foreach (object providerChecked in checkedListBox3.CheckedItems)
                selectedTypes.Add(providerChecked.ToString());

            double minimumPrice = (double)numericUpDown1.Value;
            double maximumPrice = (double)numericUpDown2.Value;

        }
    }
}
