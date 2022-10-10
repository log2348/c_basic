using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._12_AbstractTest
{
    public class AbstractTest
    {
        /*
        static void Main()
        {
            Elf elf = new Elf();
            elf.hit();
        }
        */
    }

    // 추상 클래스는 인스턴스화 될 수 없다.
    public abstract class Monster
    {
        public int hp;

        // 추상 메소드의 선언은 추상 클래스에서만 허용된다.
        // 추상 메소드는 암시적으로 virtual 함수이다.
        public abstract void hit();
    }

    public class Elf : Monster
    {
        public override void hit()
        {
            Console.WriteLine($"엘프 공격 !\n현재 hp : {hp}");
        }
    }
}
