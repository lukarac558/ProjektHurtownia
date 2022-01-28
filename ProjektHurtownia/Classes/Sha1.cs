using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjektHurtownia.Classes
{
    public static class Sha1
    {
        public static string HashPassword(string password)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
