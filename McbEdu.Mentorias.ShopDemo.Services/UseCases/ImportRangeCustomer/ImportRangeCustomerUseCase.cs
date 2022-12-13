using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportRangeCustomer;

public class ImportRangeCustomerUseCase : IUseCase<List<ImportCustomerUseCaseInput>>
{
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapter;
    private readonly IUnitOfWork _unitOfWork;

    public ImportRangeCustomerUseCase(ICustomerService customerService, IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> adapter, IUnitOfWork unitOfWork)
    {
        _customerService = customerService;
        _adapter = adapter;

        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(List<ImportCustomerUseCaseInput> useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync((async () =>
        {
            foreach (var eachCustomerInUseCaseInput in useCaseInput)
            {
                if(await _customerService.ImportCustomerAsync(_adapter.Adapt(eachCustomerInUseCaseInput)) is false)
                {
                    return false;
                }
            }

            return true;
        }));
    }
}
