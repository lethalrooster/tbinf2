using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbinf2
{

    // 1 1 | 2 2  | 3 | 5 4 5 7 9 
    //         p             p  
    //Sätter en pivot
    //
    //


    class Program
    {
        static void Rec(int a)
        {
            if (a > 0)
            {
                Console.WriteLine(a);
                Rec(a - 1);
            }
        }

        static void Main(string[] args)
        {
            Rec(10);
        }
    }
}
