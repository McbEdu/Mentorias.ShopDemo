namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;

public interface IGetUseCase<TInput, TOutput>
    where TOutput : class
    where TInput : class
{
    public Task<(bool HasDone, TOutput Output)> GetExecutionAsync(TInput input);
}
