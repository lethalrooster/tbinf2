using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tbThreads
{
    class Program
    {
        public static void OtherThreadFunction()
        {
            int count = 0;
            while (count < 5)
            {
                Console.WriteLine("Annan tråd, räknare: {0}", count);
                Thread.Sleep(1000); //Annan tråd sover i 1000 millisekunder
                count++;
            }
        }

        public static void ReadThreadFunction()
        {
            Console.WriteLine("Skriv något");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Thread other_thread = new Thread(new ThreadStart(OtherThreadFunction));
            Thread read_thread = new Thread(new ThreadStart(ReadThreadFunction));
            
            other_thread.Start();
            read_thread.Start();

            int count = 0;
            while(count < 10)
            {
                Console.WriteLine("Huvudtråd, räknare: {0}", count);
                Thread.Sleep(200); //Huvudtråd sover i 100 millisekunderr
                count++;
            }

            other_thread.Join(); //Vänta tills other_thread har kört klart
            read_thread.Join(); //Vänta tills read_thread har kört klart
            Console.WriteLine("Huvudtråd: other_thread.Join och read_thread.Join har returnerat.");
        }
    }
}
