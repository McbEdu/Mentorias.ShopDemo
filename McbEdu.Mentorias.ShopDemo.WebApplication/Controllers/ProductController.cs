using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;
using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : CustomControllerBase
{
    public ProductController([FromServices] INotificationConsumer<NotificationItem> notificationConsumer) : base(notificationConsumer)
    {
    }

    [HttpPost]
    [Route("[action]")]
    public Task<IActionResult> Import(
        [FromServices] IUseCase<ImportProductUseCaseInput> useCase,
        [FromBody] ImportProductPayload importProductPayload,
        [FromServices] IAdapter<ImportProductPayload, ImportProductUseCaseInput> adapter
        )
    {
        return RunUseCaseAsync<ImportProductUseCaseInput>(useCase, adapter.Adapt(importProductPayload), 201, 422);
    }

    [HttpPost]
    [Route("[action]")]
    public Task<IActionResult> ImportRange(
        [FromServices] IUseCase<List<ImportProductUseCaseInput>> useCase,
        [FromBody] List<ImportProductPayload> importProductPayload,
        [FromServices] IAdapter<ImportProductPayload, ImportProductUseCaseInput> adapter
        )
    {
        var inputs = new List<ImportProductUseCaseInput>();

        foreach (var item in importProductPayload)
        {
            inputs.Add(adapter.Adapt(item));
        }

        return RunUseCaseAsync<List<ImportProductUseCaseInput>>(useCase, inputs, 201, 422);
    }
}
