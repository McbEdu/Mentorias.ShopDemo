using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer;

public class ImportCustomerUseCase : IUseCase<ImportCustomerUseCaseInput>
{
    public Task<bool> ExecuteAsync(ImportCustomerUseCaseInput useCaseInput)
    {
        throw new NotImplementedException();
    }
}
