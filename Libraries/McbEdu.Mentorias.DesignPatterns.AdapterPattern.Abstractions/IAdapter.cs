namespace McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;

public interface IAdapter<TAdapter, TAdapt>
    where TAdapter : class
    where TAdapt : class
{
    public TAdapter Adapt(TAdapt adapt);
    public TAdapt Adapt(TAdapter adapter);
}
