using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentApp1._6_ExtensionMethod.ExtensionMethodTest;

namespace AssignmentApp1._6_ExtensionMethod
{
    public class ExtensionMethodTest
    {

        public class Calculator
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }

            public int Minus(int a, int b)
            {
                return a - b;
            }
        }

        /*
         * 확장 메소드를 정의할 static 클래스
         */
    }
        public static class MyExtensionTest
        {
            public static int Multiple(this Calculator calculator, int a, int b)
            {
                return a * b;
            }

            public static int Divide(this Calculator calculator, int a, int b)
        {
            return a / b;
        }
        }
}
