using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;

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

            string strConn = "DataSource = (localdb)\\MSSQLLocalDB; Initial Catalog =; BOARD; Integrated Security = true";
            public SqlConnection conn;
            int paramValue = 5;

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                // SqlCommand와 파라미터 객체 생성
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                // 0. try-catch 사용하여 예외처리
                // 1. 데이터베이스 연결
                // 2. SqlDataAdapter 클래스 사용하여 데이터 조회(DataSet 클래스에 결과 저장)
                // 4. 데이터 출력 

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }

        }
}
