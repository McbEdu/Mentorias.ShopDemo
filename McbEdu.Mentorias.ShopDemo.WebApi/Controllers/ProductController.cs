using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeProduct;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[Route("/api/v1/Manager/[controller]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsync(
        [FromBody][Required] CreateProductInputModel model,
        [FromServices] HandlerBase<CreateProductResponse, CreateProductRequest> handler,
        [FromServices] NotifiableConsumerStandard notifiableConsumer
        )
    {
        var response = await handler.Handle(new CreateProductRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);
        return StatusCode(response.HttpResponse.Status, response);
    }

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeAsync(
        [FromBody][Required] List<CreateProductInputModel> model,
        [FromServices] HandlerBase<CreateRangeProductResponse, CreateRangeProductRequest> handler,
        [FromServices] NotifiableConsumerStandard notifiableConsumer
        )
    {
        var response = await handler.Handle(new CreateRangeProductRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);
        return StatusCode(response.HttpResponse.Status, response);
    }
}
