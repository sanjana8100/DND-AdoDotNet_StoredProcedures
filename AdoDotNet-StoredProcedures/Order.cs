using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet_StoredProcedures
{
    internal class Order
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }


        public Order()
        {
        }

        public Order(string firstName, string lastName, DateTime orderDate, decimal orderTotal)
        {
            FirstName = firstName;
            LastName = lastName;
            OrderDate = orderDate;
            OrderTotal = orderTotal;
        }

    }
}
