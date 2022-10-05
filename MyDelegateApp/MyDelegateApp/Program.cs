using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateApp
{
    /// <summary>
    /// Delegate - 함수를 담는 변수
    /// 반환 타입과 매개변수가 같아야 한다.
    /// </summary>
    public class Program
    {
        delegate void MyDelegate();

        int num = 100;
        double d = 11.11;

        public Program()
        {
            MyDelegate myDelegate;
            myDelegate = FuncTest;
            myDelegate();
        }

        public void FuncTest()
        {

        }
        static void Main(string[] args)
        {
        }
    }
}
