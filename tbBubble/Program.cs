using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbBubble
{
    class Program
    {
        static void BubbleSort(List<Person> listToSort)
        {
            bool isSorted = false;

            while (isSorted == false)
            {
                isSorted = true;
                for (int i = 0; i < listToSort.Count - 1; i++)
                {
                    if (listToSort[i] > listToSort[i + 1])
                    {
                        Person temp = listToSort[i];
                        listToSort[i] = listToSort[i + 1];
                        listToSort[i + 1] = temp;

                        isSorted = false;
                    }
                }
            }
        }

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
            Person personA = new Person(29, "Jonas", 70);
            Person personB = new Person(50, "Anna", 60);
            Person personC = new Person(10, "Kalle", 85);
            Person personD = new Person(29, "Diana", 71);

            //Skapar en lista och fyller det med personerna
            List<Person> personList = new List<Person>();
            personList.Add(personA);
            personList.Add(personB);
            personList.Add(personC);
            personList.Add(personD);


            Console.WriteLine("Skriver ut osorterad lista...");
            PrintList(personList);
            Console.WriteLine("");

            //---Testdel för att testa sin Bubblesort samt räkna på tid
            var watch = System.Diagnostics.Stopwatch.StartNew(); //Starta klocka
            BubbleSort(personList); //Sortera
            watch.Stop(); //Stanna klocka
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Det tog " + elapsedMs + "ms att sortera listan med " + personList.Count + " antal personer\n\n");


            Console.WriteLine("Skriver ut sorterad lista (jämför just nu med ålder, från minst till störst)...");
            PrintList(personList);
            Console.WriteLine("\n");




            //---Testdel för att testa IComparable
            Console.WriteLine("Sorterar listan (jämför just nu med ålder, från minst till störst)...");
            personList.Sort();
            Console.WriteLine("...klarsorterad\n");

            Console.WriteLine("Skriver ut sorterad lista (jämför just nu med ålder, från minst till störst)...");
            PrintList(personList);
            Console.WriteLine("\n");




            //---Testdel, för att testa större än (>) och mindre än (<) operatorerna
            if (personA > personB)
            {
                Console.WriteLine("PersonA väger mer än PersonB");
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
        }
    }
}
