using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbClassExample
{
    class Employee : Human
    {
        string profession;

        public Employee(string profession)
        {
            this.profession = profession;
        }

        public void UseItem()
        {
            if (profession == "Teacher")
            {
                Console.WriteLine("Writing on white board");
            }
            else if (profession == "janitor")
            {
                Console.WriteLine("Using hammer");
            }
        }
        
    }
}
