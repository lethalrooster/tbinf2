using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tbMonoGameRotateImage
{
    class ThreadData //Klass som bakar in en tråd och data
    {
        Thread t; //Klassen ska ha sin egen tråd
        bool runThread; //En flagga som avgör om tråden ska köra eller ej

        int data; //Behöver klart inte enbart vara ett heltal, enbart som exempel.

        public ThreadData() //Konstruktor för klassen
        {
            data = 0; //Sätt värde till 0
            runThread = false; //Anta att tråden inte ska köras, därav false
            t = new Thread(new ThreadStart(Running)); //Definera tråden med en ThreadStart samt vilken metod som ska köras (Running-metoden)
        }

        private void Running() //Metoden som exekveras när tråden startas
        {
            while (runThread) //Så länge runThread är true
            {
                data++; //Öka data med 1
                Thread.Sleep(1000); //Låt tråden sova i 1 sekund (1000 ms)
            }
        }

        public void StartThread() //Metoden som anropar att startar tråden, för att kunna starta tråden från t.ex. Game1.cs
        {
            runThread = true; //Sätter flaggan till true
            t.Start(); //Starta tråden
        }

        public void StopThread() //Metoden som avslutar trådloopen genom att sätta flagga till false
        {
            runThread = false;
        }

        public string GetData //Property som möjliggör att man kan hämta datan (som en sträng)
        {
            get
            {
                return data.ToString();
            }
        }
    }
}
