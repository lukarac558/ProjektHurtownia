using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHurtownia
{
    public class User
    {
        int idUser;
        string login;
        string password;
        string permission;
        string name;
        string surname;
        string city;
        string street;
        string residenceNumber;
        string postcode;

        public User(string login, string password, string name, string surname, string city, string street, string residenceNumber, string postcode)
        {
            this.Login = login;
            this.Password = password;
            this.Permission = "Customer";
            this.Name = name;
            this.Surname = surname;
            this.City = city;
            this.Street = street;
            this.ResidenceNumber = residenceNumber;
            this.Postcode = postcode;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Permission { get => permission; set => permission = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string ResidenceNumber { get => residenceNumber; set => residenceNumber = value; }
        public string Postcode { get => postcode; set => postcode = value; }
    }
}
