using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder;

public class ImportOrderUseCase : IUseCase<ImportOrderUseCaseInput>
{
    private readonly IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> _adapterOrder;

    public ImportOrderUseCase(IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> adapterOrder)
    {
        _adapterOrder = adapterOrder;
    }

    public Task<bool> ExecuteAsync(ImportOrderUseCaseInput useCaseInput)
    {
        throw new NotImplementedException();
    }
}
