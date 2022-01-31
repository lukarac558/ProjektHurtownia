using System;

namespace ProjektHurtownia
{
    public class Order
    {
        int idOrder;
        int idUser;       
        DateTime orderDate;

        public Order(int idOrder, int idUser, DateTime orderDate)
        {
            this.IdOrder = idOrder;
            this.IdUser = idUser;
            this.OrderDate = orderDate;
        }

        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
    }
}
