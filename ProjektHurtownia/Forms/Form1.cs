﻿using MySqlConnector;
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
            // else
            //     MessageBox.Show("Podany typ nie istnieje.");
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
