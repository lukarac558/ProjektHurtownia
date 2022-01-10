using MySqlConnector;
using ProjektHurtownia.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //DateBase.AddNewType("Rolki");
           //int typeId = DateBase.GetTypeId(textBox2.Text);
           // if (typeId > 0)
           //     DateBase.AddNewProduct(new Product("Piłka", typeId, 1, 100, 150.49, 1));
           // else
           //     MessageBox.Show("Podany typ nie istnieje.");

           //DateBase.AddNewProvider("Adidas");
           // DateBase.Register(new User("login", "pass", "Jan", "Kowalski", "Rybnik","Gliwicka",75,"44-300"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox7.Text;
            string haslo = textBox8.Text;

            DateBase.Login(login, haslo);

            if (DateBase.idUser > 0)
            {
                Form2 zaloguj = new Form2();
                Hide();
                zaloguj.ShowDialog();
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 filtruj = new Form3();
            Hide();
            filtruj.ShowDialog();
            Close();
        }
    }
}
