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
        string name;

        public Person()
        {
            age = -1;
            name = "unknown";
        }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
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

        public int CompareTo(Person other)
        {
            return this.age.CompareTo(other.age); //lägg till *-1 för att ändra sorteringsordning;
        }

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
