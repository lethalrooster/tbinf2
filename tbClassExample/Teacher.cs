using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbClassExample
{
    class Teacher : Employee
    {
        string subject;

        public Teacher()
        {

        }

        public void UseItem()
        {
            Console.WriteLine("Writing on white board");
        }
    }
}
