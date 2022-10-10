using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionApp
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string connectionString = "...";

            IDbConnection connection = new SqlConnection(connectionString);

            connection.Open();

            IDbCommand command = new SqlCommand();

            command.Connection = connection;

            IDbTransaction transaction;

            transaction = connection.BeginTransaction(); //Enlisting database

            command.Transaction = transaction;

            try
            {

                /* 어쩌고 저쩌고 */

                transaction.Commit();

            }

            catch
            {

                transaction.Rollback(); //Abort transaction

            }

            finally
            {

                connection.Close();

            }
        }
    }
}
