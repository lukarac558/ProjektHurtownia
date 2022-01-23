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
        int idOrderPosition;
        int idUser;       
        DateTime orderDate;

        public Order(int idOrder, int idOrderPosition, int idUser, DateTime orderDate)
        {
            this.IdOrder = idOrder;
            this.IdOrderPosition = idOrderPosition;
            this.IdUser = idUser;
            this.OrderDate = orderDate;
        }

        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdOrderPosition { get => idOrderPosition; set => idOrderPosition = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
    }
}
