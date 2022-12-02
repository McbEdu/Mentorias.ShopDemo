using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Validators;

namespace McbEdu.Mentorias.ShopDemo.Tests.Domain.Validators;

public class TestProductValidator
{
    private readonly AbstractValidator<ProductStandard> _productValidator;

    public TestProductValidator()
    {
        _productValidator = new ProductValidator();
    }

    [Theory]
    [InlineData("Code", "Description")]
    public void TestValidProductCredentials(string code, string description)
    {
        var product = new ProductStandard(Guid.NewGuid(), code, description);

        Assert.True(_productValidator.Validate(product).IsValid);
    }

    [Fact]
    public void TestInvalidProductCodeCredential()
    {
        var product = new ProductStandard(Guid.NewGuid(), new String('a', 151), "description");

        Assert.False(_productValidator.Validate(product).IsValid);
    }

    [Fact]
    public void TestInvalidProductDescriptionCredential()
    {
        var product = new ProductStandard(Guid.NewGuid(), new String('a', 149), new String('a', 501));

        Assert.False(_productValidator.Validate(product).IsValid);
    }

    [Fact]
    public void TestInvalidResultsNumberOfErrors()
    {
        var product = new ProductStandard(Guid.NewGuid(), new String('a', 151), new String('a', 501));

        Assert.Equal(2, _productValidator.Validate(product).Errors.Count);
    }
}
