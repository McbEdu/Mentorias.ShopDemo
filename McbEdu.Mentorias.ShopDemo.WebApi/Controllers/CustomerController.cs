﻿using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[Route("/api/v1/Manager/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerInputModel model,
        [FromServices] HandlerBase<CreateCustomerResponse, CreateCustomerRequest> handler,
        [FromServices] NotifiableConsumerStandard notifiableConsumer
        )
    {
        var response = await handler.Handle(new CreateCustomerRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);
        return StatusCode(response.HttpResponse.Status, response);
    }
}
