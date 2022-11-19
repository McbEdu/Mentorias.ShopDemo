using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Consumer;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[Route("/api/v1/Manager/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsy(
        [FromBody][Required] CreateCustomerInputModel model,
        [FromServices] HandlerBase<CreateCustomerResponse, CreateCustomerRequest> handler,
        [FromServices] INotificationConsumer notifiableConsumer)
    {
        var response = await handler.Handle(new CreateCustomerRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);
        return StatusCode(response.HttpResponse.Status, response);
    }

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeAsync(
        [FromBody][Required] List<CreateCustomerInputModel> model,
        [FromServices] HandlerBase<CreateRangeCustomerResponse, CreateRangeCustomerRequest> handler,
        [FromServices] INotificationConsumer notifiableConsumer)
    {
        var response = await handler.Handle(new CreateRangeCustomerRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);
        return StatusCode(response.HttpResponse.Status, response);
    }
}
