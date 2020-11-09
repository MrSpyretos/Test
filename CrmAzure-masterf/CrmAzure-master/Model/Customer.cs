using System.Collections.Generic;
using System.Linq;

namespace CrmAzure.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        // this is a navigation property
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public decimal Gross => Orders.Sum(i => i.Cost);
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
