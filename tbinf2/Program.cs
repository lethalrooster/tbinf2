using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbinf2
{
    class Program
    {
        static void LinarySearch(List<int> list, int elementToFind)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == elementToFind)
                {
                    Console.WriteLine("Elementet " + elementToFind + " ligger på plats " + i);
                    break;
                }
                if (i == list.Count - 1 && list.Count != elementToFind)
                {
                    Console.WriteLine("Elementet " + elementToFind + " finns inte i listan");
                }
            }
        }

        static void BinarySearch(List<int> list, int element)
        {
            // Går långsammare än linjärsökning. Även fast jag endast halverar listan en gång borde sökningen 
            // fortfarande gå snabbare?

            // Förstår i och med din genomgång hur man ska halvera listan 
            // flera gånger med hjälp av while-loop

            int median = list.Count / 2;

            if (element < median)
            {
                for (int i = median - 1; i >= 0; i--)
                {
                    if (list[i] == element)
                    {
                        Console.WriteLine("Elementet " + element + " ligger på plats " + i);
                        break;
                    }
                    if (i == 0 && list[0] != element)
                    {
                        Console.WriteLine("Elementet " + element + " finns inte i listan");
                    }
                }
            }
            if (element > median)
            {
                for (int i = median - 1; i < list.Count; i++)
                {
                    if (list[i] == element)
                    {
                        Console.WriteLine("Elementet " + element + " ligger på plats " + i);
                        break;
                    }
                    if (i == list.Count - 1 && list.Count != element)
                    {
                        Console.WriteLine("Elementet " + element + " finns inte i listan");
                    }
                }
            }
        }

        static void BubbelSort(List<int> listToSort)
        {
            // inga konstigheter

            bool sorted = false;

            Console.WriteLine("=====BUBBELSORT=====");
            for (int i = 0; i < listToSort.Count; i++)
            {
                Console.WriteLine(listToSort[i]);
            }

            while (sorted != true)
            {
                sorted = true;

                for (int i = 0; i < listToSort.Count - 1; i++)
                {
                    if (listToSort[i + 1] < listToSort[i])
                    {
                        int temp = listToSort[i];

                        listToSort[i] = listToSort[i + 1];

                        listToSort[i + 1] = temp;

                        sorted = false;
                    }
                }
            }

            Console.WriteLine("Sorterad: ");
            for (int i = 0; i < listToSort.Count; i++)
            {
                Console.WriteLine(listToSort[i]);
            }
        }

        static void QuickSort(List<int> listToSort)
        {

            // endast spån, saknar bl.a. variabler att basera sökningen på (left, right)

            Console.WriteLine("=====QUICKSORT=====");
            for (int i = 0; i < listToSort.Count; i++)
            {
                Console.WriteLine(listToSort[i]);
            }

            for (int i = 0; i < listToSort.Count; i++)
            {
                Random random = new Random();

                int pivit = random.Next(0, listToSort.Count);

                Console.WriteLine("Pivit " + pivit);

                for (int j = pivit; j < listToSort.Count; j++)
                {
                    if (listToSort[i] <= listToSort[pivit])
                    {
                        int temp = listToSort[i];

                        listToSort[i] = listToSort[pivit];

                        listToSort[pivit] = temp;
                    }
                }

                Console.WriteLine("Sorterad: ");
                for (int j = 0; j < listToSort.Count; j++)
                {
                    Console.WriteLine(listToSort[j]);
                }

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("GitHub kan förbättras");

            List<int> numbers = new List<int>();


            //Random rand = new Random(0);

            //for (int i = 0; i < 1000; i++)
            //{
            //    numbers.Add(rand.Next(0, 100));
            //}

            for (int i = 1; i < 1000000; i++)
            {
                numbers.Add(i);
            }

            int element = 500001;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            LinarySearch(numbers, element);
            var elapsed = watch.ElapsedMilliseconds;

            Console.WriteLine("Linjärsökning tog " + elapsed);

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            BubbelSort(numbers);
            var elapsed2 = watch.ElapsedMilliseconds;

            Console.WriteLine("Bubbelsort tog " + elapsed2);

            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            BinarySearch(numbers, element);
            var elapsed3 = watch.ElapsedMilliseconds;

            Console.WriteLine("Binärsökning tog " + elapsed3);
        }
    }
}
