using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 1;
            int n = 1;

            List<int> someList = new List<int>();
            
            try
            {
                someList.Add(10);
                Console.WriteLine(t / n);
            }
            catch(System.DivideByZeroException)
            {
                Console.WriteLine("Du försökte dela med noll");
            }
            catch(System.NullReferenceException)
            {
                Console.WriteLine("Listan är inte initierad");
            }
            catch
            {
                Console.WriteLine("Alla andra exceptions");
            }
            finally
            {
                Console.WriteLine("Skrivs alltid ut");
            }
            
            Console.WriteLine("Körs vidare");
        }
    }
}
