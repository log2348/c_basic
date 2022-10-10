using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._20_Delegate
{
    public class DelegateTest
    {
        // 대리자 생성
        // 매개변수가 없고 반환타입이 void인 메소드만 참조 가능
        delegate void Delegate();

        /*
        static void Main()
        {
            // 대리자 객체 생성
            Delegate myDelegate;

            // Print 메소드 참조
            myDelegate = Print;

            // 대리자를 이용한 메소드 호출
            myDelegate();

            // 메소드를 참조하는 형식
            // 1.
            myDelegate = new Delegate(Print);

            // 2.
            myDelegate = Print;

            // 3.
            myDelegate += Print;

        }
        */

        public static void Print()
        {
            Console.WriteLine("대리자를 통한 메소드 호출");
        }
    }
}
