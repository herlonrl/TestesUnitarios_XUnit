using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer;
using FluentAssertions;
using Moq;

namespace UnitTests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<ICustomerAgeValidator> _customerAgeValidatorMock;

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerAgeValidatorMock = new Mock<ICustomerAgeValidator>();
        }

        [Fact]
        public void Given_Customer_When_IsNotOfLegalAge_Then_ShouldTrhowException()
        {
            // Arrage
            var customer = new CustomerEntity ("Maria", DateTime.Now);
            var customerService = new CustomerService(_customerRepositoryMock.Object, _customerAgeValidatorMock.Object);

            _customerAgeValidatorMock.Setup( v => v.IsOfLegalAge(customer.BirtDate)).Returns(false);

            // Act
            Action action = () => customerService.AddCustomer(customer);

            // Assert
            action.Should().Throw<ArgumentException>();
            _customerRepositoryMock.Verify(r => r.AddCustomer(customer), Times.Never);

        }

        [Fact]
        public void Given_Customer_When_IsOfLegalAge_Then_ShouldAddCustomer()
        {
            // Arrage
            var customer = new CustomerEntity("Maria", DateTime.Now);
            var customerService = new CustomerService(_customerRepositoryMock.Object, _customerAgeValidatorMock.Object);

            _customerAgeValidatorMock.Setup(v => v.IsOfLegalAge(customer.BirtDate)).Returns(true);

            // Act
            customerService.AddCustomer(customer);

            // Assert
            _customerRepositoryMock.Verify(r => r.AddCustomer(customer), Times.Once);

        }
    }
}
