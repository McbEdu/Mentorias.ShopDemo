using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
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
    public Task<IActionResult> Import(
        [FromServices] IUseCase<ImportCustomerUseCaseInput> useCase,
        [FromBody] ImportCustomerPayload importCustomerPayload,
        [FromServices] IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput> adapter
        )
    {
        return RunUseCaseAsync<ImportCustomerUseCaseInput>(useCase, adapter.Adapt(importCustomerPayload), 201, 422);
    }
}