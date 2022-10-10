using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._3_RefAndOut
{
    public class RefAndOutTest
    {
        static void SetValueRef(ref string str)
        {
            /*
             * ref 키워드는 인수를 참조로 전달하는 데 사용된다.
             * 즉, 해당 매개변수의 값이 메소드에서 변경되면 호출하는 메소드에 반영된다.
             */

            str = "refString";
            Console.WriteLine("SetValueRef 메소드 호출 : " + str);
        }

        static void SetValueOut(out string str)
        {
            /*
             * out 키워드는 ref 키워드와 같은 인수를 전달하는 데도 사용되지만,
             * 값을 할당하지 않고도 인수를 전달할 수 있다.
             * out 키워드를 사용하여 전달된 인수는 호출 메소드로 돌아가기 전에
             * 호출된 메소드에서 초기화 되어야 한다.
             */
            str = "outString";
            Console.WriteLine("SetValueOut 메소드 호출 : " + str);
        }

    }

}
