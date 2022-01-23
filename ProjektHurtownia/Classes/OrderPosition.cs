using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHurtownia.Classes
{
    public class OrderPosition
    {
        int idOrderPosition;        
        double totalCost;
        int count;
        int idProduct;
        DateTime guaranteeEnd;

        public OrderPosition(int idOrderPosition, double totalCost, int count, int idProduct, DateTime guaranteeEnd)
        {
            IdOrderPosition = idOrderPosition;
            TotalCost = totalCost;
            Count = count;
            IdProduct = idProduct;
            GuaranteeEnd = guaranteeEnd;
        }

        public OrderPosition(int idProduct, int count)
        {
            IdProduct = idProduct;
            Count = count;           
        }
        public int IdOrderPosition { get => idOrderPosition; set => idOrderPosition = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        public int Count { get => count; set => count = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public DateTime GuaranteeEnd { get => guaranteeEnd; set => guaranteeEnd = value; }
    }
}
