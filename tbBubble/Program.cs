using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbBubble
{
    class Program
    {
        static void PrintList(List<Person> listToPrint)
        {
            foreach (Person p in listToPrint)
            {
                Console.WriteLine(p.Name + " age: " + p.Age);
            }
        }

        static void Main(string[] args)
        {
            //Skapar ett antal objekt av klassen Person
            Person personA = new Person(29, "Jonas");
            Person personB = new Person(50, "Anna");
            Person personC = new Person(10, "Kalle");
            Person personD = new Person(29, "Diana");

            //Skapar en lista och fyller det med personerna
            List<Person> personList = new List<Person>();
            personList.Add(personA);
            personList.Add(personB);
            personList.Add(personC);
            personList.Add(personD);

            
            Console.WriteLine("Skriver ut osorterad lista...");
            PrintList(personList);
            Console.WriteLine("");

            //Testdel för att testa 
            Console.WriteLine("Sorterar listan (jämför just nu med ålder, från minst till störst)...");
            personList.Sort();
            Console.WriteLine("...klarsorterad\n");

            Console.WriteLine("Skriver ut sorterad lista (jämför just nu med ålder, från minst till störst)...");
            PrintList(personList);
            Console.WriteLine("");


            //Testdel, för att testa större än (>) och mindre än (<) operatorerna
            if (personA > personB)
            {
                Console.WriteLine("PersonA är äldre än PersonB");
            }
            else if (personA < personB)
            {
                Console.WriteLine("PersonB är äldre än PersonA");
            }


            //Testdel, för att testa lika med (==) och inte lika med (!=) operatorerna
            if (personA == personB)
            {
                Console.WriteLine("PersonA är lika gammal som PersonB");
            }

            if (personA == personD)
            {
                Console.WriteLine("PersonA är lika gammal som PersonD");
            }

            if (personB != personC)
            {
                Console.WriteLine("PersonB och PersonC är inte lika gamla");
            }


            //Bubble sort med en Person
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine();

        }
    }
}
