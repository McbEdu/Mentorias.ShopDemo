using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Validators;
using System.Xml.Linq;

namespace McbEdu.Mentorias.ShopDemo.Tests.Domain.Validators;

public class TestCustomerValidator
{
    private readonly AbstractValidator<CustomerStandard> _customerValidator;

    public TestCustomerValidator() 
    {
        _customerValidator = new CustomerValidator();
    }

    [Theory]
    [InlineData("Nome", "Sobrenome", "email@valido.com", "2022-12-02")]
    public void TestCustomerValidatorInRegularOcasion(string name, string surname, string email, string birthDate)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.Parse(birthDate));

        var validationResult = _customerValidator.Validate(customer);

        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [InlineData("012345678901234567890123456789012345678901234567891", "Sobrenome", "email@valido.com", "2022-12-02")]
    public void TestCustomerValidatorWithInvalidName(string name, string surname, string email, string birthDate)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.Parse(birthDate));

        var validationResult = _customerValidator.Validate(customer);

        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData("Nome", 
        "1234567890123456789012345678901234567890123456789112345678901234567890123456789012345678901234567891123456789012345678901234567890123456789012345678911", 
        "email@valido.com", 
        "2022-12-02")]
    public void TestCustomerValidatorWithInvalidSurname(string name, string surname, string email, string birthDate)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.Parse(birthDate));

        var validationResult = _customerValidator.Validate(customer);

        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData("Nome", "Sobrenome", "12345678901234567890123456789012345678901234567891123456789012345678901234567890123456789012345678911234567890123456789012345678901234567890123456789111234567890123456789012345678901234567890123456789112345678901234567890123456789012345678901234567891123456789012345678901234567890123456789012345678911", "2022-12-02")]
    public void TestCustomerValidatorWithInvalidEmail(string name, string surname, string email, string birthDate)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.Parse(birthDate));

        var validationResult = _customerValidator.Validate(customer);

        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData("Nome", "Sobrenome", "email@valido.com")]
    public void TestCustomerValidatorWithInvalidBirthDate(string name, string surname, string email)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.UtcNow.AddDays(1));

        var validationResult = _customerValidator.Validate(customer);

        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData("Nome", "Sobrenome", "emailvalido", "2022-12-02")]
    public void TestCustomerValidatorInRegularOcasionWithIrregularEmail(string name, string surname, string email, string birthDate)
    {
        var customer = new CustomerStandard(Guid.NewGuid(), name, surname, email, DateTime.Parse(birthDate));

        var validationResult = _customerValidator.Validate(customer);

        Assert.True(validationResult.IsValid);
    }

}
