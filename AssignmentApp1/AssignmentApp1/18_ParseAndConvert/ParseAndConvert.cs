using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._18_ParseAndConvert
{
    public class ParseAndConvert
    {
        static void Main()
        {
            // Parse 예제
            string str = String.Empty;

            try
            {
                int result = int.Parse(str);
                Console.WriteLine(result);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // '' 파싱 불가
            // 예외 발생

            // Convert 예제
            int num = -1;
            bool flag = true;

            while (flag)
            {
                Console.Write("숫자를 입력하세요 : ");
                string input = Console.ReadLine();

                try
                {
                    num = Convert.ToInt32(input);

                    if(num <= Int32.MaxValue)
                    {
                        Console.WriteLine("결과 값 : " + num);
                    }
                    else
                    {
                        Console.WriteLine("입력 값이 범위를 벗어났습니다.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e2)
                {
                    Console.WriteLine(e2.Message);
                }

                Console.Write("다시 실행하시겠습니까? (Y/N) : ");
                string answer = Console.ReadLine();

                if(answer.ToUpper() != "Y")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    flag = false;
                }

            }
        }
    }
}
