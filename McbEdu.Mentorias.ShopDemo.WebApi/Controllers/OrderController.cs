﻿using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

[Route("/api/v1/Manager/[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsync(
        [FromBody][Required] CreateOrderInputModel model,
        [FromServices] HandlerBase<CreateOrderResponse, CreateOrderRequest> handler,
        [FromServices] INotificationConsumer notifiableConsumer
        )
    {
        var response = await handler.Handle(new CreateOrderRequest(DateTime.Now, TypeVerbRequest.HttpPost, model));
        response.AddNotification(notifiableConsumer);

        if (response.HttpResponse.Status == 200 || response.HttpResponse.Status == 201)
        {
            return StatusCode(response.HttpResponse.Status);
        }

        return StatusCode(response.HttpResponse.Status, response);
    }
}
