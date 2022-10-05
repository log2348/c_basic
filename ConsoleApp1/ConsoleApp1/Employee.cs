using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee : Person
    {
        public string id = "M0123";
        
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Employee ID : {0}", id);
        }
    }
}
