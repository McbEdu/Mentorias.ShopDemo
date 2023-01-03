using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
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

        List<string>? createResponse = CreateResponse();

        if (createResponse is null)
        {
            return response ? StatusCode(statusCodeSuccess, null) : StatusCode(statusCodeError, null);
        }else if (createResponse.Count == 1)
        {
            return response ? StatusCode(statusCodeSuccess, createResponse[0]) : StatusCode(statusCodeError, createResponse[0]);
        }
        else
        {
            return response ? StatusCode(statusCodeSuccess, createResponse) : StatusCode(statusCodeError, createResponse);
        }
    }

    protected async Task<IActionResult> RunGetUseCaseAsync<TUseCaseInput, TUseCaseOutput>(
        IGetUseCase<TUseCaseInput, IList<TUseCaseOutput>> useCase,
        TUseCaseInput useCaseInput)
        where TUseCaseInput : class
        where TUseCaseOutput : IList<TUseCaseOutput>
    {
        var response = await useCase.GetExecutionAsync(useCaseInput);

        if (response.HasDone == false)
        {
            return BadRequest(CreateResponse());
        }
        else
        {
            if (response.Output.Count < 1)
            {
                return Ok();
            }

            return Ok(response.Output);
        }
    }

    private List<string>? CreateResponse()
    {
        var messages = new List<string>();

        var notifications = _notificationConsumer.GetNotificationItems();

        if (notifications.Count == 0)
        {
            return null;
        }

        foreach(var item in _notificationConsumer.GetNotificationItems())
        {
            messages.Add(item.Message);
        }

        return messages;
    }
}
