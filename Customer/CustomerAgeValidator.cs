using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerAgeValidator : ICustomerAgeValidator
    {
        private const int eighteenYearsInDays = 6570; // => 365 * 18

        public bool IsOfLegalAge(DateTime birtDate) // é > 18 
        {
            return (DateTime.Now -  birtDate.Date).Days > eighteenYearsInDays;
        }

    }
}
