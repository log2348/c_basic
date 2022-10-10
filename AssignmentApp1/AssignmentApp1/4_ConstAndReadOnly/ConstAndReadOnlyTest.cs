using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1.ConstAndReadOnly
{
    public class ConstAndReadOnlyTest
    {
        public const int number = 100;

        public readonly string str = "readonly test string";

        public ConstAndReadOnlyTest()
        {
            str = "readonly test string change 1";
        }

        public ConstAndReadOnlyTest(bool isAnotherInstance)
        {
            str = "readonly test string change 2";
        }

        /*
        static void Main()
        {
            // const
            // 컴파일 타입 상수 (컴파일 시 const 변수의 값을 가져온다)
            // 변수 선언과 동시에 할당
            // Stack 메모리에 할당
            // 단, static 선언을 하면 Heap 메모리에 저장 가능
             

            Console.WriteLine(number);

            // 로컬 변수를 상수로 선언
            const int num = 10;
            Console.WriteLine(num);
             
            // readonly
            // 런타임 상수 (exe 또는 dll 사용할 때 변수의 값 가져온다)
            // 생성자에서 값 초기화 가능
            // Heap 메모리에 할당
             
            ConstAndReadOnlyTest readonlyInstance = new ConstAndReadOnlyTest();
            Console.WriteLine(readonlyInstance.str);

            ConstAndReadOnlyTest readonlyAnotherInstance = new ConstAndReadOnlyTest(true);
            Console.Write(readonlyAnotherInstance.str);

        }
        */

    }
}
