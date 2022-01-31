using System;

namespace ProjektHurtownia.Classes
{
    public class OrderPosition
    {
        int idOrderPosition;
        int idOrder;
        double totalCost;
        int count;
        int idProduct;
        DateTime guaranteeEnd;

        public OrderPosition(int idOrderPosition, int idOrder, double totalCost, int count, int idProduct, DateTime guaranteeEnd)
        {
            IdOrderPosition = idOrderPosition;
            IdOrder = idOrder;
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
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        public int Count { get => count; set => count = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public DateTime GuaranteeEnd { get => guaranteeEnd; set => guaranteeEnd = value; }       
    }
}
