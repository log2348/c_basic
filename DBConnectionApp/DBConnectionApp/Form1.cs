using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnectionSample db = new DBConnectionSample();
            db.Open();

            string sql = "SELECT * FROM dbo.TB_Board";

            DataSet ds = db.GetDataSet(sql);
            db.Close();
        }
    }
}
