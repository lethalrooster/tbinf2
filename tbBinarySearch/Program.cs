using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbBinarySearch
{
    class Program
    {
        static int BinarySearch(List<int> numbers, int value)
        {
            int startIndex = 0;
            int endIndex = numbers.Count;

            while (startIndex < endIndex)
            {
                int index = (startIndex + endIndex) / 2;

                if (value == numbers[index])
                {
                    return index;
                }
                else if (value > numbers[index])
                {
                    startIndex = index + 1;
                }
                else if (value < numbers[index])
                {
                    endIndex = index;
                }
            }

            return -1;
        }

        static int LinarySearch(List<int> numbers, int value)
        {
            for (int i = 0; i < numbers.Count; i++)
            { 
                if (numbers[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Random rand = new Random(0); //sätt seed till 0, eller annat heltal, så får du samma slumptal varje gång, olika tal får olika samma slumptal

            //Skapa en lista med 10000 tal, mellan 0 och 10000
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100000000; i++)
            {
                numbers.Add(rand.Next(0, 100000000));
            }

            int valueToFind = 500; //Vill hitta värdet 500 (kan välja ett värde mellan 0 och 99999999)

            //LINJÄRSÖKNING I OSORTERAD LISTA
            var watch = System.Diagnostics.Stopwatch.StartNew(); //Starta klocka
            int index = LinarySearch(numbers, valueToFind); //Utför linjärsökning
            watch.Stop(); //Stanna klocka
            long elapsedMs = watch.ElapsedMilliseconds; //Hämta hur länge klockan varit igång (i millisekunder)
            Console.WriteLine("---LINJÄRSÖKNING---");
            Console.WriteLine("Värdet " + valueToFind + " ligger på plats " + index);
            Console.WriteLine("Det tog " + elapsedMs + "ms att hitta första värdet " + valueToFind + " i en osorterade listan med " + numbers.Count + " heltal\n\n");

            //SORTERA LISTA MED INBYGGD METOD SORT
            watch = System.Diagnostics.Stopwatch.StartNew(); //Starta klocka
            numbers.Sort(); //Sorterar med den inbyggda sorteringsfunktionen
            watch.Stop(); //Stanna klocka
            elapsedMs = watch.ElapsedMilliseconds; //Hämta hur länge klockan varit igång (i millisekunder)
            Console.WriteLine("Det tog " + elapsedMs + "ms att sortera listan med " + numbers.Count + " heltal\n\n");

            //BINÄRSÖKNING I SORTERAD LISTA
            watch = System.Diagnostics.Stopwatch.StartNew(); //Starta klocka
            index = BinarySearch(numbers, valueToFind); //Utför binärsökning
            watch.Stop(); //Stanna klocka
            elapsedMs = watch.ElapsedMilliseconds; //Hämta hur länge klockan varit igång (i millisekunder)
            Console.WriteLine("---BINÄRSÖKNING---");
            Console.WriteLine("Värdet " + valueToFind + " ligger på plats " + index);
            Console.WriteLine("Det tog " + elapsedMs + "ms att hitta värdet " + valueToFind + " i listan med " + numbers.Count + " heltal\n\n");

           

        }
    }
}
