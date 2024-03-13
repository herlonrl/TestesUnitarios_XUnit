using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepositoy;
        private readonly ICustomerAgeValidator _customerAgeValidator;

        public CustomerService(ICustomerRepository customerRepositoy, ICustomerAgeValidator customerAgeValidator)
        {
            _customerRepositoy = customerRepositoy;
            _customerAgeValidator = customerAgeValidator;
        }

        public void AddCustomer(CustomerEntity customer)
        {
            if(!_customerAgeValidator.IsOfLegalAge(customer.BirtDate))
            {
                throw new ArgumentException($"Cliente {customer.Name} é menor de idade, não pode adicionar.");
            }
            
            _customerRepositoy.AddCustomer(customer);
        }

        public List<CustomerEntity> GetAllCustomer() 
        {
            return _customerRepositoy.GetAllCustomers();
        }
    }
}
