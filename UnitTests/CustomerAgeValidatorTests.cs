using Customer;
using FluentAssertions;

namespace UnitTests
{
    public class CustomerAgeValidatorTests
    {
        [Fact]
        public void Given_BirthDate_When_ofLegalAge_Then_ShouldReturnFalse()
        {
            // Arange
            var birthDate = DateTime.Now;
            var customerAgeValidator = new CustomerAgeValidator();

            // Act
            var ofLegalAge = customerAgeValidator.IsOfLegalAge(birthDate);

            // Assert
            //Assert.False(ofLegalAge);
            ofLegalAge.Should().BeFalse();
        }

        [Fact]
        public void Given_BirthDate_When_ofLegalAge_Then_ShouldReturnTrue()
        {
            // Arange
            var birthDate = DateTime.Now.AddYears(-20);
            var customerAgeValidator = new CustomerAgeValidator();

            // Act
            var ofLegalAge = customerAgeValidator.IsOfLegalAge(birthDate);

            // Assert
            ofLegalAge.Should().BeTrue();

        }
    }
}