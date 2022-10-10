using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._5_MethodParams
{
    public class MethodParamsTest
    {
        public static void UseParams(params int[] list)
        {
            /*
             * params 키워드를 사용하면
             * 개수의 제한 없이 매개 변수를 넘길 수 있다.
             */
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

        }
        
        /*
        static void Main()
        {
            // 매개변수 여러 개
            UseParams(1, 2, 3, 4);

            // 매개변수 없음
            UseParams();
        }
        */
    }
}
