using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentApp1._16_Hashtable
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * DataRow -> DataTable -> DataSet
             * 
             * DataRow는 데이터가 모인 한 열(레코드)
             * DataTable은 DataRow의 집합체
             * Table들이 모인 것이 DataSet
             */

            DataTable dt = new DataTable();

            ArrayList nameList = new ArrayList();
            ArrayList ageList = new ArrayList();
            ArrayList hpList = new ArrayList();

            // 이름 리스트에 추가
            nameList.Add("박지현");
            nameList.Add("김지현");
            nameList.Add("이지현");

            // 나이 리스트에 추가
            ageList.Add(55);
            ageList.Add(66);
            ageList.Add(77);

            // 연락처 리스트에 추가
            hpList.Add("010-0000-0000");
            hpList.Add("010-1111-1111");
            hpList.Add("010-2222-2222");

            // Table에 컬럼명 추가
            dt.Columns.Add("이름", typeof(string));
            dt.Columns.Add("나이", typeof(int));
            dt.Columns.Add("연락처", typeof(string));

            // 리스트에 있는 값 만큼 DataRow에 추가한 후 DataTable에 넣기
            for (int i = 0; i < nameList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["이름"] = nameList[i];
                dr["나이"] = ageList[i];
                dr["연락처"] = hpList[i];

                dt.Rows.Add(dr);
            }

            // 데이터 추가 (행)
            dt.Rows.Add("한지현", "77", "010-3333-3333");

            // DataTable에 있는 값을 DataGridView에 넣기
            dataGridView1.DataSource = dt;

            // DataSet 생성
            DataSet ds = new DataSet();

            // DataSet에 DataTable 추가
            ds.Tables.Add(dt);
        }

    }
}
