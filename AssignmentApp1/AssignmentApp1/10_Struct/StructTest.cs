using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._10_Struct
{
    public class StructTest
    {
        /*
        static void Main(string[] args)
        {
            // 구조체 변수 선언
            Student student;

            // 구조체 변수 필드에 값 할당
            student.name = "박지현";
            student.age = 99;

            // 구조체 변수 필드 호출
            student.displayField();
        }
        */
    }

    struct Student
    {
        /*
         * Class는 참조 타입(Reference Type)이지만,
         * Struct는 값 타입(Value Type)이다.
         * 
         */
        public string name;
        public int age;

        public void displayField()
        {
            Console.WriteLine("name : " + name + " / age : " + age);
        }
    }
    
}
