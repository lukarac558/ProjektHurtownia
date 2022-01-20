using ProjektHurtownia.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia.Forms
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex login = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{3,20}$");
            Regex password = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$");
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex residenceNumber = new Regex(@"^[0-9]{1,4}[a-zA-Z]{0,1}$");
            Regex postcode = new Regex(@"^[0-9]{2}(?:-[0-9]{3})?$");
            Regex name = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]{3,20}$");
            Regex surname = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ_ -]{2,30}$");
            Regex street = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ_ -]{3,60}$");
            Regex city = new Regex(@"^[a-zA-Z-zżźćńółęąśŻŹĆĄŚĘŁÓŃ_ -]{2,30}$");

            string error = "";

            if (!login.IsMatch(loginTextBox.Text))
                error += "Login musi zawierać od 3 do 20 znaków i nie zaczynać się od cyfry.\n";

            if (!password.IsMatch(passwordTextBox.Text))
                error += "Hasło musi zawierać od 8 do 20, w tym minimum 1 cyfrę i 1 literę.\n";

            if (!passwordTextBox.Text.Equals(password2TextBox.Text))
                error += "Podane hasła nie zgadzają się.\n";

            if (!email.IsMatch(emailTextBox.Text))
                error += "Wprowadzono niepoprawny email.\n";

            if (!name.IsMatch(nameTextBox.Text))
                error += "Imię musi zawierać od 3 do 20 znaków.\n";

            if (!surname.IsMatch(surnameTextBox.Text))
                error += "Nazwisko musi zawierać od 2 do 30 znaków.\n";

            if (!postcode.IsMatch(postcodeTextBox.Text))
                error += "Wprowadzono niepoprawny kod pocztowy.\n";

            if (!city.IsMatch(cityTextBox.Text))
                error += "Miasto musi zawierać od 2 do 30 znaków.\n";

            if (!street.IsMatch(streetTextBox.Text))
                error += "Ulica musi zawierać od 3 do 60 znaków\n";

            if (!residenceNumber.IsMatch(residenceNumberTextBox.Text))
                error += "Wprowadzono niepoprawny numer budynku.\n";

            if (error != "")
                MessageBox.Show(error, "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DateBase.Register(new User(loginTextBox.Text, Sha1.HashPassword(passwordTextBox.Text), nameTextBox.Text, surnameTextBox.Text, cityTextBox.Text,
                    streetTextBox.Text, residenceNumberTextBox.Text, postcodeTextBox.Text));

                MessageBox.Show("Poprawnie utworzono konto. Od teraz możesz zalogować się na konto.");

                Login loginL = new Login();
                Hide();
                loginL.ShowDialog();
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
    }
}
