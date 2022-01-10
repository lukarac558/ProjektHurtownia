using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektHurtownia
{
    public class Product 
    {
        int productId;
        string productName;
        int typeId;
        int disciplineId;
        int unitQuantity;
        double unitPrice;
        int providerId;

        public Product(int productId, string productName, int typeId, int disciplineId, int unitQuantity, double unitPrice, int providerId)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.TypeId = typeId;
            this.DisciplineId = disciplineId;
            this.UnitQuantity = unitQuantity;
            this.UnitPrice = unitPrice;
            this.ProviderId = providerId;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int TypeId { get => typeId; set => typeId = value; }
        public int DisciplineId { get => disciplineId; set => disciplineId = value; }
        public int UnitQuantity { get => unitQuantity; set => unitQuantity = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int ProviderId { get => providerId; set => providerId = value; }
    }
}
