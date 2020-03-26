using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbQuickSort
{
    class Program
    {
        private static void QuickSort(List<int> listToSort, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(listToSort, left, right);

                if (pivot > 1)
                {
                    QuickSort(listToSort, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(listToSort, pivot + 1, right);
                }
            }

        }

        private static int Partition(List<int> listToSort, int left, int right)
        {
            int pivot = listToSort[left];
            while (true)
            {

                while (listToSort[left] < pivot)
                {
                    left++;
                }

                while (listToSort[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (listToSort[left] == listToSort[right]) return right;

                    int temp = listToSort[left];
                    listToSort[left] = listToSort[right];
                    listToSort[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static void Main(string[] args)
        {
            Random rand = new Random(0);

            List<int> numbers = new List<int>();
            for (int i = 0; i < 100000000; i++)
            {
                numbers.Add(rand.Next(0, 100000000));
            }

            //SORTERA LISTA MED INBYGGD METOD SORT
            var watch = System.Diagnostics.Stopwatch.StartNew(); //Starta klocka
            QuickSort(numbers, 0, numbers.Count); //Sorterar med den inbyggda sorteringsfunktionen
            watch.Stop(); //Stanna klocka
            long elapsedMs = watch.ElapsedMilliseconds; //Hämta hur länge klockan varit igång (i millisekunder)
            Console.WriteLine("Det tog " + elapsedMs + "ms att sortera listan med " + numbers.Count + " heltal\n\n");
        }
    }
}
