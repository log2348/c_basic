using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp1._13_Property
{
    public class Student
    {
        private string major; // field
        public string Major // property
        {
            get { return major; } // get method
            set
            {
                major = value;
            }
        } // set method
    }

}
