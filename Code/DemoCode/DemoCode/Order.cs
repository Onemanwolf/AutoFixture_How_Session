using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class Order : OrderBase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Customer.CustomerName}";
        }

    }

    public class Customer
    {
        public string CustomerName { get; set; }

    }

    public class OrderItems
    {
        public int Id { get; set; }
        public string Item { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

    }

    public class OrderBase
    {
        DateTime OrderDate { get; set; }
    }
}
