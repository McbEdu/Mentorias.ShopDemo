namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;

public interface IUseCase<TUseCaseInput>
    where TUseCaseInput : class
{
    public Task<bool> ExecuteAsync(TUseCaseInput useCaseInput);
}
