using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbBubble
{
    class Person : IComparable<Person>
    {
        int age;
        int weight;
        string name;

        public Person()
        {
            age = -1;
            name = "unknown";
        }

        public Person(int age, string name, int weight)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
        }

        public int Age
        {
            get{return age;}
            set{age = value;}
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int CompareTo(Person other) //Måste implementeras då Person ärver av IComparable, som kräver att metoden finns
        {
            return age.CompareTo(other.age); //lägg till *-1 efter sista parantesen för att ändra sorteringsordning;
        }

        //---------------------------------------

        public static bool operator <(Person P1, Person P2)
        {
            return (P1.age < P2.age);
        }

        public static bool operator >(Person P1, Person P2)
        {
            return (P1.age > P2.age);
        }

        public static bool operator ==(Person P1, Person P2)
        {
            return (P1.age == P2.age);
        }

        public static bool operator !=(Person P1, Person P2)
        {
            return (P1.age != P2.age);
        }

        public static bool operator <=(Person P1, Person P2)
        {
            return (P1.age <= P2.age);
        }

        public static bool operator >=(Person P1, Person P2)
        {
            return (P1.age >= P2.age);
        }


        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

    }
}
