using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetAllCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByEmail.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByNameOrSurname.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByRangeBirthDate.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;
using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : CustomControllerBase
{
    public CustomerController([FromServices] INotificationConsumer<NotificationItem> notificationConsumer) : base(notificationConsumer)
    {
    }

    [HttpPost]
    [Route("[action]")]
    public Task<IActionResult> Import(
        [FromServices] IUseCase<ImportCustomerUseCaseInput> useCase,
        [FromBody] ImportCustomerPayload importCustomerPayload,
        [FromServices] IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput> adapter
        )
    {
        return RunUseCaseAsync<ImportCustomerUseCaseInput>(useCase, adapter.Adapt(importCustomerPayload), 201, 422);
    }

    [HttpPost]
    [Route("[action]")]
    public Task<IActionResult> ImportRange(
        [FromServices] IUseCase<List<ImportCustomerUseCaseInput>> useCase,
        [FromBody] List<ImportCustomerPayload> importCustomerPayload,
        [FromServices] IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput> adapter
        )
    {
        var inputs = new List<ImportCustomerUseCaseInput>();

        foreach (var item in importCustomerPayload)
        {
            inputs.Add(adapter.Adapt(item));
        }

        return RunUseCaseAsync<List<ImportCustomerUseCaseInput>>(useCase, inputs, 201, 422);
    }

    [HttpGet]
    [Route("GetByPagination")]
    public async Task<IActionResult> GetAsync(
        [FromServices] IGetUseCase<GetAllCustomerUseCaseInput, List<Customer>> getUseCase,
        [FromQuery] int page,
        [FromQuery] int offset)
    {
        return await RunGetUseCaseAsync(getUseCase, new GetAllCustomerUseCaseInput(page, offset));
    }

    [HttpGet]
    [Route("GetFilteredByEmail")]
    public async Task<IActionResult> GetByEmail(
        [FromServices] IGetUseCase<GetCustomerByEmailUseCaseInput, List<Customer>> getUseCase,
        [FromQuery] int page,
        [FromQuery] int offset,
        [FromQuery] string email)
    {
        return await RunGetUseCaseAsync(getUseCase, new GetCustomerByEmailUseCaseInput(page, offset, email));
    }

    [HttpGet]
    [Route("GetFilteredByNameOrSurname")]
    public async Task<IActionResult> GetByNameOrSurname(
        [FromServices] IGetUseCase<GetCustomerByNameOrSurnameUseCaseInput, List<Customer>> getUseCase,
        [FromQuery] int page,
        [FromQuery] int offset,
        [FromQuery] string name,
        [FromQuery] string surname)
    {
        return await RunGetUseCaseAsync(getUseCase, new GetCustomerByNameOrSurnameUseCaseInput(page, offset, name, surname));
    }

    [HttpGet]
    [Route("GetFilteredByBirthDate")]
    public async Task<IActionResult> GetByBirthdate(
        [FromServices] IGetUseCase<GetCustomerByRangeBirthDateUseCaseInput, List<Customer>> getUseCase,
        [FromQuery] int page,
        [FromQuery] int offset,
        [FromQuery] DateTime startIn,
        [FromQuery] DateTime finishIn)
    {
        return await RunGetUseCaseAsync(getUseCase, new GetCustomerByRangeBirthDateUseCaseInput(page, offset, startIn, finishIn));
    }
}