namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;

public interface IUseCase<TUseCaseInput>
    where TUseCaseInput : class
{
    public Task<bool> ExecuteAsync(TUseCaseInput useCaseInput);
}
