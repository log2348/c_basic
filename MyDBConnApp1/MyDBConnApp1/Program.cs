using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDBConnApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            MySample mySample = new MySample();
            mySample.SelectById();
            // mySample.UpdateByProcedure();
            // mySample.SelectByIdProcedure();
        }

    }
}

