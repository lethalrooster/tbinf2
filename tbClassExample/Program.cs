using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Human temp = new Human("Jonas", "901017", "male", "someadress", "07000000", "jonas.stroberg@helsingborg.se", "jope1031");
            Human temp2 = new Human();


            Employee e = new Employee("Teacher");
            Teacher t = new Teacher();
        }
    }
}
