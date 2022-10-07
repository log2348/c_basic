using System.Data.Linq.Mapping;

namespace LINQTest
{
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column]
        public string CustomerID { get; set; }
        [Column]
        public string City { get; set; }
        public string CompanyName { get; set; }

        public override string ToString()
        {
            return CustomerID + "\t" + City;
        }

    }
}