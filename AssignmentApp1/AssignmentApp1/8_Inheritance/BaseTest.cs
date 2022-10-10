using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._8_Inheritance
{
    public class BaseTest
    {
        /**
         * 
         * base 키워드는
         * 파생 클래스(자식 클래스) 내에서 기본 클래스(부모 클래스)의
         * 멤버에 접근 하는 데 사용된다.
         * 
         */

        /*
        static void Main()
        {
            Cat cat = new Cat();
            cat.GetMyPetInfo();
        }
        */
    }

    public class Pet
    {
        protected string name;
        protected int age;

        public virtual void GetMyPetInfo()
        {
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"나이 : {age}");
        }
    }

    class Cat : Pet
    {
        public string breed;

        public override void GetMyPetInfo()
        {

            // 부모 클래스의 GetMyPetInfo() 메소드 호출
            base.GetMyPetInfo();
            Console.WriteLine($"품종 : {breed}");
        }
    }
}
