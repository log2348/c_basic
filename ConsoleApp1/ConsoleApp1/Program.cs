using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.GetInfo();

            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("반복문 연습 중 : " + i);
            }

            string[] strArr = { "a", "b", "c" };

            foreach (string item in strArr)
            {
                Debug.WriteLine("foreach문 연습 중 : " + item);
            }
        }
    }
}
