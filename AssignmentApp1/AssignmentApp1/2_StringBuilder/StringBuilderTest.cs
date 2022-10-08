using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._2_StringBuilder
{
    public class StringBuilderTest
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("StringBuilder Test");
            Console.WriteLine(sb);

            sb.Append("Value1"); // 개행 x
            sb.AppendLine("Value2"); // 개행 o
            sb.AppendLine("Value3");

            sb.AppendFormat("안녕하세요. {0} 입니다.", "박지현");

            Console.WriteLine(sb);
        }
    }
}
