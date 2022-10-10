using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._20_Delegate
{
    public class FuncAndActionTest
    {

        // Action<T>
        // 반환값이 필요없는 Event
        public event Action<int, bool> ActionEvent = null;

        // Func<T>
        // 반환값이 필요한 Event
        public event Func<int, bool, bool> FuncEvent = null;
        
        public void SendActionEvent()
        {
            if (ActionEvent != null)
            {
                ActionEvent(14, false);
            }
        }

        public void SendFuncEvent()
        {
            if (null != FuncEvent)
            {
                if (FuncEvent(14, false))
                {
                    Console.WriteLine("FuncEvent 결과 : true");
                }
                else
                {
                    Console.WriteLine("FuncEvent 결과 : false");
                }
            }
        }

        public class FuncAndActionConsumer
        {
            public FuncAndActionTest funcAndActionTest;

            public FuncAndActionConsumer()
            {
                funcAndActionTest = new FuncAndActionTest();
                funcAndActionTest.ActionEvent += FuncAndActionTest_ActionEvent;
                funcAndActionTest.FuncEvent += FuncAndActionTest_FuncEvent;
            }

            private bool FuncAndActionTest_FuncEvent(int arg1, bool arg2)
            {
                // 이벤트 처리
                // 100까지의 랜덤수를 2로 나누어 떨어지면 true, 아니면 false
                bool result = arg1 % 2 == 0 ? true : false;

                // 결과 반환
                return result;
            }

            private void FuncAndActionTest_ActionEvent(int arg1, bool arg2)
            {
                // 이벤트 처리
                // 반환값 없음
            }
        }
    }
}
