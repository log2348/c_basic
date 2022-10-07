using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataTable dt = new DataTable();

            // 컬럼 생성
            dt.Columns.Add("no", typeof(int));
            dt.Columns.Add("name", typeof(string));

            // 데이터 삽입 (행 삽입)
            // 1.
            DataRow dr = dt.NewRow();
            dr["no"] = 1;
            dr["name"] = "박지현";
            dt.Rows.Add(dr);

            // 2.
            dt.Rows.Add(new object[] { 2, "박" });

            // 데이터 추출 방법
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int no = Convert.ToInt32(dt.Rows[i]["no"]);
                string name = dt.Rows[i]["name"].ToString();
            }

            foreach (DataRow rows in dt.Rows)
            {
                int no = Convert.ToInt32(dr["no"]);
                string name = dr["name"].ToString();
            }

        }
    }
}
