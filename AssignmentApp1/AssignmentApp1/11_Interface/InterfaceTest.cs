using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._11_Interface
{
    public class InterfaceTest
    {
        /*
        static void Main()
        {
            Person person = new Person();
            Cat cat = new Cat();

            person.Eat();
            cat.Eat();
            
        }
        */
    }

    interface IAnimal
    {
        void Eat();
    }

    class Person : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("사람이 밥을 먹습니다.");
        }
    }

    class Cat : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("고양이가 먹이를 먹습니다.");
        }
    }
}
