using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        protected string name = "박지현";

        public virtual void GetInfo()
        {
            Console.WriteLine("Name : {0}", name);
        }
    }
}
