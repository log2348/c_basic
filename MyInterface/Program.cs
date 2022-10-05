using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Eat();

            //Lion lion = new Lion();

            //lion.Eat();

        }
    }

    class Person : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("사람이 밥을 먹습니다.");
        }    
        
        public void Run()
        {

        }

        public void Sleep()
        {

        }
    }

    class Lion : IAnimal
    {
        private int id;

        private string name;

        private int age;
        public string Name { get; set; } // 자동 구현 프로퍼티

        private int Age { get; set; } = 0; // 프로퍼티의 기본값 설정 가능

        public int Id
        {
            get { return age; } // get method
            set { age = value; } // set method
        }

        public Lion(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public void Eat()
        {
            Console.WriteLine("사자가 고기를 먹습니다.");
        }

        public void Run()
        {

        }

        public void Sleep()
        {

        }
    }

    interface IAnimal
    {
        void Eat();
        void Run();
        void Sleep();
    }
}
