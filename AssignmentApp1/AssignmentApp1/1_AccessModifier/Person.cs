using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._1_AccessModifier
{
    /*
     * 접근 제한자
     */
    public class Person
    {
        /*
         * private : 해당 클래스 내에서만 접근 가능
         */
        private string name;

        /*
         * protected : 해당 클래스 내, 자식 클래스에서 접근 가능
         */
        protected int age;


        /*
         * public : 어디에서나 접근 가능
         */
        public string Name { 
            get { return name; }
            set { name = value; }
        }   

        /*
         * internal
         * 같은 프로젝트 내에서는 public처럼 사용이 가능하지만
         * 다른 프로젝트에서는 접근할 수 없음
         */
        internal void PrintHello()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
