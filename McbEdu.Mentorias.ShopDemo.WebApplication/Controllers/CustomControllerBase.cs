using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers;

public class CustomControllerBase : ControllerBase
{
    private readonly INotificationConsumer<NotificationItem> _notificationConsumer;

    protected CustomControllerBase([FromServices] INotificationConsumer<NotificationItem> notificationConsumer)
    {
        _notificationConsumer = notificationConsumer;
    }

    protected async Task<IActionResult> RunUseCaseAsync<TUseCaseInput>(
        IUseCase<TUseCaseInput> useCase,
        TUseCaseInput useCaseInput,
        int statusCodeSuccess,
        int statusCodeError
        ) where TUseCaseInput : class
    {
        var response = await useCase.ExecuteAsync(useCaseInput);

        return response ? StatusCode(statusCodeSuccess, CreateResponse()) : StatusCode(statusCodeError, CreateResponse());
    }

    private List<string> CreateResponse()
    {
        var messages = new List<string>();

        foreach(var item in _notificationConsumer.GetNotificationItems())
        {
            messages.Add(item.Message);
        }

        return messages;
    }
}
