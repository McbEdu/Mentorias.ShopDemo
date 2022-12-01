using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder;

public class ImportOrderUseCase : IUseCase<ImportOrderUseCaseInput>
{
    public ImportOrderUseCase()
    {

    }

    public Task<bool> ExecuteAsync(ImportOrderUseCaseInput useCaseInput)
    {
        throw new NotImplementedException();
    }
}
