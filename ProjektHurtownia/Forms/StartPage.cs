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
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Przejście do rejstracji
        {
            Register register = new Register();
            Hide();
            register.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e) // Przejście do logowania
        {
            Login login = new Login();
            Hide();
            login.ShowDialog();
            Close();
        }
    }
}
