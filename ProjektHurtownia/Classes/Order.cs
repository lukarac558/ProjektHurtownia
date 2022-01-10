using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHurtownia
{
    public class Order
    {
        int idOrder;
        int idProduct;
        int idUser;
        int count;
        DateTime orderDate;
        double totalCost;

        public Order(int idOrder, int idProduct, int idUser, int count, DateTime orderDate, double totalCost)
        {
            this.IdOrder = idOrder;
            this.IdProduct = idProduct;
            this.IdUser = idUser;
            this.Count = count;
            this.OrderDate = orderDate;
            this.TotalCost = totalCost;
        }

        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int Count { get => count; set => count = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
    }
}
