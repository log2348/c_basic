using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace LINQTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            ObjectQuery1();
            //ObjectQuery2();
        }
        static void NumQuery()
        {
            var numbers = new int[] { 1, 4, 9, 16, 25, 36 };

            // 기존 쿼리문
            var resultQuery = from p in numbers
                              where (p % 2) == 0
                              select p;

            // 람다식 변환
            var resultLamda = numbers.Where(a => a % 2 == 0);

            Console.WriteLine("Result:");
            foreach (var val in resultLamda)
            {
                Console.WriteLine(val);
            }

        }

        static IEnumerable<Customer> CreateCustomers()
        {
            /*
            return new List<Customer>
            {
                new Customer { CustomerID = "ALFKI", City = "Berlin"    },
                new Customer { CustomerID = "BONAP", City = "Marseille" },
                new Customer { CustomerID = "CONSH", City = "London"    },
                new Customer { CustomerID = "EASTC", City = "London"    },
                new Customer { CustomerID = "FRANS", City = "Torino"    },
                new Customer { CustomerID = "LONEP", City = "Portland"  },
                new Customer { CustomerID = "NORTS", City = "London"    },
                new Customer { CustomerID = "THEBI", City = "Portland"  }
            };
            */

            return from c in XDocument.Load("Customers.xml")
                   .Descendants("Customers").Descendants()
                   select new Customer
                   {
                        City = c.Attribute("City").Value,
                        CustomerID = c.Attribute("CustomerID").Value
                    };

        }

        static NorthwindDS.CustomersDataTable CreateCustomers2()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "select * from customers", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=true");

            NorthwindDS.CustomersDataTable table =
                new NorthwindDS.CustomersDataTable();

            adapter.Fill(table);

            return table;
        }

        static void ObjectQuery1()
        {
            // 기존 쿼리문
            var resultQuery = from c in CreateCustomers()
                          where c.City == "London"
                          select c;

            // 람다식 변환
            var resultLamda = CreateCustomers().Where(a => a.City == "London");

            foreach (var c in resultLamda)
            {
                Console.WriteLine(c);
            }
        }

        static void ObjectQuery2()
        {
            // 기존 쿼리문
            var resultQuery = from c in CreateCustomers()
                          where c.City == "London"
                          select c;
            
            // 람다식 변환
            var resultLamda = CreateCustomers().Where(c => c.City == "London").Select(c => c);

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.CustomerID, c.City);
            }
        }

        static void ObjectQuery3()
        {

            var db = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            db.Log = Console.Out;

            // 기존 쿼리문
            var resultQuery = from c in db.GetTable<Customer>()
                          where c.City == "London"
                          select c;

            // 람다식 변환
            var resultLamda = db.GetTable<Customer>().Where(c => c.City == "London").Select(c => c);

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.CustomerID, c.City);
            }
        }

        static void ObjectQuery4()
        {
            var db = new NorthwindDataContext();
            db.Log = Console.Out;

            // 기존 쿼리문
            var resultQuery = from c in db.Customers
                          where c.City == "London"
                          select c;

            // 람다식 변환
            var resultLamda = db.Customers.Where(a => a.City == "London").Select(a => a);

            foreach (var c in resultLamda)
                Console.WriteLine("{0}\t{1}", c.CustomerID, c.City);
        }

        static void ObjectQuery5()
        {
            var db = new NorthwindDataContext();
            db.Log = Console.Out;
            
            // 기존 쿼리문
            var resultQuery = from c in db.Customers
                          from o in c.Orders
                          where c.City == "London"
                          select new
                          {
                              c.ContactName,
                              o.OrderID
                          };

            // 람다식 변환
            var resultLamda = db.Customers.SelectMany(
                c => c.Orders.Where(o => c.City == "London"),
                (c, o) => new { c.ContactName, o.OrderID });

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.ContactName, c.OrderID);
            }
        }

        static void ObjectQuery6()
        {
            var db = new NorthwindDataContext();
            db.Log = Console.Out;

            // 기존 쿼리문
            var resultQuery = from c in db.Customers
                          where c.City == "London"
                          orderby c.ContactName descending
                          select new { c.ContactName, c.CustomerID };

            // 람다식 변환
            var resultLamda = db.Customers.Where(c => c.City == "London")
                .OrderByDescending(c => c.ContactName)
                .Select(c => new {c.ContactName, c.CustomerID});

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.CustomerID, c.ContactName);
            }
        }

        static void ObjectQuery7()
        {
            var db = new NorthwindDataContext();
            db.Log = Console.Out;

            // 기존 쿼리문
            var resultQuery = from c in db.Customers
                          group c by c.City into g
                          orderby g.Count() ascending
                          select new { City = g.Key, Count = g.Count() };


            // 람다식 변환
            var resultLamda = db.Customers.GroupBy(c => c.City).Select(g => new { City = g.Key, Count = g.Count() }).OrderBy(g => g.Count);

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.City, c.Count);
            }
        }

        static void ObjectQuery8()
        {
            var db = new NorthwindDataContext();
            db.Log = Console.Out;

            // 기존 쿼리문
            var resultQuery = from c in db.Customers
                          join e in db.Employees on c.City equals e.City
                          group e by e.City into g
                          select new { City = g.Key, Count = g.Count() };

            // 람다식 변환
            var resultLamda = db.Customers.Join(db.Employees, c => c.City, p => p.City, (c, p) => new { c.City }).GroupBy(p => p.City).Select(c => new { City = c.Key, Count = c.Count() });

            foreach (var c in resultLamda)
            {
                Console.WriteLine("{0}\t{1}", c.City, c.Count);
            }
        }

        static void ModifyData()
        {
            var db = new NorthwindDataContext();

            Console.WriteLine("Number Created Before: {0}",
                db.Customers.Where(c => c.CustomerID == "ADVCA").Count());

            Customers newCustomer = new Customers
            {
                CompanyName = "AdventureWorks Cafe",
                CustomerID = "ADVCA"
            };

            db.Customers.InsertOnSubmit(newCustomer);
            db.SubmitChanges();

            Console.WriteLine("Number Created After: {0}",
                db.Customers.Where(c => c.CustomerID == "ADVCA").Count());
        }

        static void ModifyData2()
        {
            var db = new NorthwindDataContext();

            Console.WriteLine("Number Updated Before: {0}",
                db.Customers.Where(c => c.ContactName == "New Contact").Count());

            var existingCustomer = db.Customers.First();
            existingCustomer.ContactName = "New Contact";
            db.SubmitChanges();

            Console.WriteLine("Number Updated After: {0}",
                db.Customers.Where(c => c.ContactName == "New Contact").Count());

        }

        public static void XMLQuery()
        {
            var doc = XDocument.Load("Customers.xml");

            Console.WriteLine("XML Document:\n{0}", doc);

            var results = from c in doc.Descendants("Customer")
                            where c.Attribute("City").Value == "London"
                            select c;

            XElement transformedResults = new XElement("Londoners",
                                            from customer in results
                                            select new XElement("Contact",
                                            new XAttribute("ID", customer.Attribute("CustomerID").Value),
                                            new XElement("Name", customer.Attribute("ContactName").Value),
                                            new XElement("City", customer.Attribute("City").Value)));

            Console.WriteLine("Results:\n{0}", transformedResults);
            transformedResults.Save("Output.xml");

            Console.WriteLine("Results:\n");

            foreach (var contact in results)
            {
                Console.WriteLine("{0}\n", contact);
            }

        }

        static void InvokeSproc()
        {
            var db = new NorthwindDataContext();

            foreach (var r in db.Ten_Most_Expensive_Products())
            {
                Console.WriteLine(r.TenMostExpensiveProducts + "\t" + r.UnitPrice);
            }
        }

        static void OperatorQuery1()
        {
            var db = new NorthwindDataContext();

            var matchingCustomers = db.Customers
                .Where(c => c.City.Contains("London"));

            foreach (var c in matchingCustomers)
            {
                Console.WriteLine("{0}\t{1}\t{2}", c.CustomerID, c.ContactName, c.City);
            }
        }

        static void OperatorQuery2()
        {
            var db = new NorthwindDataContext();

            var avgCost = db.Products
                .Where(p => p.ProductName.StartsWith("A"))
                .Select(p => p.UnitPrice)
                .Average();

            Console.WriteLine("Average cost = {0:c}", avgCost);
        }

        static void OperatorQuery3()
        {
            var db = new NorthwindDataContext();

            // 기존 쿼리문
            var resultQuery = from p in db.Products
                                 where p.ProductName.Contains("Ch")
                                 select p;

            // 람다식 변환
            var resultLamda = db.Products.Where(a => a.ProductName.Contains("Ch")).Select(a => a);

            var productsByName = db.Products
                .Where(p => p.UnitPrice < 5)
                .Select(p => p.ProductName);

            var productsDetails = db.Products
                .Where(p => p.Discontinued)
                .Select(p => new {p.ProductName, p.UnitPrice});

            Console.WriteLine(">>Products containing Ch");
            foreach (var product in resultLamda)
            {
                Console.WriteLine("{0}, {1}", product.ProductName, product.ProductID);
            }

            Console.WriteLine("\n\n>>Products with low prices (names only printed)");
            foreach (var product in productsByName)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\n\n>>Products that are discontinued (as new types)");
            foreach (var product in productsDetails)
            {
                Console.WriteLine("{0}, {1}", product.ProductName, product.UnitPrice);
            }

        }

        static void OperatorQuery4()
        {
            var db = new NorthwindDataContext();

            var janBirthdays = db.Employees.Where(e => e.BirthDate.Value.Month == 1);

            foreach (var emp in janBirthdays)
            {
                Console.WriteLine("{0}, {1}", emp.LastName, emp.FirstName);
            }

        }

        static void OperatorQuery5()
        {
            var db = new NorthwindDataContext();

            int before = db.Customers.Count();
            int after1 = db.Customers.Where(c => c.City == "London").Count();
            int after2 = db.Customers.Count(c => c.City == "London");

            Console.WriteLine("Before={0}, After={1}/{2}", before, after1, after2);

        }

        static void OperatorQuery6()
        {
            var db = new NorthwindDataContext();

            var minCost = db.Products.Min(p => p.UnitPrice);
            var maxCost = db.Products.Select(p => p.UnitPrice).Max();
            var sumCost = db.Products.Sum(p => p.UnitsOnOrder);
            var avgCost = db.Products.Select(p => p.UnitPrice).Average();

            Console.WriteLine("Min = {0:c}, Max = {1:c}, Sum = {2}, Avg = {3:c}", minCost, maxCost, sumCost, avgCost);

        }

        static void OperatorQuery7()
        {
            var db = new NorthwindDataContext();

            var customers1 = db.Customers.Where(c => c.Orders.Any());

            var customers2 = db.Customers.Where(c => c.Orders.All(o => o.Freight < 50));

            foreach (var c in customers1)
            {
                Console.WriteLine("{0}", c.ContactName);
            }

            foreach (var c in customers2)
            {
                Console.WriteLine("{0}", c.ContactName);
            }
        }

        static void OperatorQuery8()
        {
            var db = new NorthwindDataContext();
            var customers = db.Customers.Where(c => c.City == "London");

            Customers[] custArray = customers.ToArray();
            List<Customers> custList = customers.ToList();

            foreach (var cust in custArray)
            {
                Console.WriteLine("{0}", cust.ContactName);
            }

            foreach (var cust in custList)
            {
                Console.WriteLine("{0}", cust.ContactName);
            }
        }

    }

}
