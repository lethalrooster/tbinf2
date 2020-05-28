using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbClassExample
{
    class Human
    {
        string name;
        string ssn;
        string gender;
        string adress;
        string phone;
        string email;
        string id;

        public Human(string name, string ssn, string gender, string adress, string phone, string email, string id)
        {
            this.name = name;
            this.ssn = ssn;
            this.gender = gender;
            this.adress = adress;
            this.phone = phone;
            this.email = email;
            this.id = id;
        }

        public Human()
        {

        }
    }
}
