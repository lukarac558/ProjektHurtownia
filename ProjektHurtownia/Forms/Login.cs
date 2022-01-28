using MySqlConnector;
using ProjektHurtownia.Classes;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateBase.Login(textBox7.Text, Sha1.HashPassword(textBox8.Text));

            if (DateBase.idUser > 0)
            {
                SelectionPanel panel = new SelectionPanel();
                Hide();
                panel.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartPage start = new StartPage();
            Hide();
            start.ShowDialog();
            Close();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
