using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;
using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : CustomControllerBase
{
    public OrderController([FromServices] INotificationConsumer<NotificationItem> notificationConsumer) : base(notificationConsumer)
    {
    }

    [HttpPost]
    [Route("[action]")]
    public Task<IActionResult> Import(
        [FromServices] IUseCase<ImportOrderUseCaseInput> useCase,
        [FromBody] ImportOrderPayload importCustomerPayload,
        [FromServices] IAdapter<ImportOrderPayload, ImportOrderUseCaseInput> adapter
        )
    {
        return RunUseCaseAsync<ImportOrderUseCaseInput>(useCase, adapter.Adapt(importCustomerPayload), 201, 422);
    }
}
