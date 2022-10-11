using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class DBConnectionSample
    {
        string connString = "DataSource = (localdb)\\MSSQLLocalDB; Initial Catalog =; BOARD; Integrated Security = true";
        public SqlConnection conn;

        public void Open()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connString);
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
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
                throw ex;
            }
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



    }
}
