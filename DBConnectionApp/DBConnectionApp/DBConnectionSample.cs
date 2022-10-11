using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionApp
{
    public class DBConnectionSample
    {
        string strConn = "DataSource = (localdb)\\MSSQLLocalDB; Initial Catalog =; BOARD; Integrated Security = true";
        public SqlConnection conn;

        public void Open()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    Console.WriteLine("DB 연결에 성공하였습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB 연결에 실패하였습니다.");
                Console.WriteLine(ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(strConn); conn.Open();

            return ds;

        }
    }
}
