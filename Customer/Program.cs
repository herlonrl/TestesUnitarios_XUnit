using System.Diagnostics.CodeAnalysis;

namespace Customer
{
    [ExcludeFromCodeCoverage] // Exclui do teste
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				CustomerEntity maria = new("Maria", DateTime.Now.AddYears(-20));
                CustomerEntity joao = new("João", DateTime.Now.AddYears(-19));
                CustomerEntity carla = new("Carla", DateTime.Now.AddYears(-17));

                ICustomerRepository customerRepositoy = new CustomerRepository();
                ICustomerAgeValidator customerAgeValidator = new CustomerAgeValidator();

                CustomerService customerService = new(customerRepositoy, customerAgeValidator);

                customerService.AddCustomer(maria);
                customerService.AddCustomer(joao);

                List<CustomerEntity> customers = customerService.GetAllCustomer();

                customers.ForEach(x => Console.WriteLine($"Cliente {x.Name} adicionado(a) com sucesso. "));

                customerService.AddCustomer(carla);

            }
            catch (Exception e)
			{

                Console.WriteLine(e.Message);
            }
        }
    }
}
