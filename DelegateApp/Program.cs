using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    // delegate 생성
    delegate void DelegateTest();

    // 매개변수가 없고 반환 타입이 void형인 메소드만 참조시킬 수 있다.
    public class Program
    {
        static void Main(string[] args)
        {
            DelegateTest myDelegateTest;

            // Print라는 메소드 참조
            myDelegateTest = Print;

            // 대리자를 이용한 메소드 호출
            myDelegateTest();

            // 메소드 참조 방식

        }

        public static void Print()
        {
            Console.WriteLine("대리자를 통한 메소드 호출");
            Debug.WriteLine("디버그 창 테스트 ~~ ");
        }
    }
}
