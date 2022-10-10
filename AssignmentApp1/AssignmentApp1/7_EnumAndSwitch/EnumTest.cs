using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._7_Enum
{
    public class EnumTest
    {
        /**
         * 
         * Enum
         * 열거형 상수를 표현하기 위한 것
         */

        enum City
        {
            // 숫자형 타입과 호환 가능

            Seoul, // 0
            Daejun, // 1
            Busan = 5, 
            Jeju
        }

        /*
        static void Main()
        {
            City myCity;

            myCity = City.Seoul;

            int cityValue = (int)myCity;

            if (myCity == City.Seoul)
            {
                Console.WriteLine("Seoul");
            }

            switch (myCity)
            {
                case City.Seoul:
                    Console.WriteLine("서울");
                    break;

                case City.Daejun:
                    Console.WriteLine("대전");
                    break;

                case City.Busan:
                    Console.WriteLine("부산");
                    break;

                default:
                    Console.WriteLine("지정된 도시가 없습니다.");
                    break;
            }
        }
        */
    }
}
