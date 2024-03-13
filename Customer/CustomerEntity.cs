using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerEntity
    {
        public CustomerEntity(string name, DateTime birthDate)
        {
            Name = name;
            BirtDate = birthDate;
        }

        public string Name { get; set; }
        public DateTime BirtDate { get; set;}

    }
}
