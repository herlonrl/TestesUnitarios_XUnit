namespace Customer
{
    public interface ICustomerRepository
    {
        void AddCustomer(CustomerEntity customer);

        List<CustomerEntity> GetAllCustomers();
    }
}