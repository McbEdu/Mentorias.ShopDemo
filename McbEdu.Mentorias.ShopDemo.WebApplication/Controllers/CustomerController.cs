using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetAllCustomer.Inputs;
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
    [Route("Get")]
    public async Task<IActionResult> GetAsync(
        [FromServices] IGetUseCase<GetAllCustomerUseCaseInput, List<Customer>> getUseCase,
        [FromQuery] int page,
        [FromQuery] int offset)
    {

        return await RunGetUseCaseAsync(getUseCase, new GetAllCustomerUseCaseInput(page, offset));
    }

    [HttpGet]
    [Route("GetByEmail")]
    public async Task<IActionResult> GetByEmail()
    {
        return StatusCode(501);
    }

    [HttpGet]
    [Route("GetByNameOrSurname")]
    public async Task<IActionResult> GetByNameOrSurname()
    {
        return StatusCode(501);
    }

    [HttpGet]
    [Route("GetByBirthDate")]
    public async Task<IActionResult> GetByBirthdate()
    {
        return StatusCode(501);
    }
}