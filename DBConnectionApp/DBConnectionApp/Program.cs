using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Transactions;

namespace DBConnectionApp
{
    internal static class Program
    {
        private static TransactionScopeAsyncFlowOption tranOpt;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {

                TransactionOptions tranOpt = new TransactionOptions();
                tranOpt.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;  // IsolationLevel 셋팅
                                                                                              //tranOpt.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;  // IsolationLevel 셋팅

                using (TransactionScope scope1 = new TransactionScope(TransactionScopeOption.Required, tranOpt))
                {
                }
                scope.Complete();
            }
        }
    }
}
