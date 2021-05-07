namespace Faro.MetrologyManager.Infra.CrossCutting.Factories.Interfaces
{
    public interface IFactoryWithParameter<out T, TParameter>
        : IFactory<T>
    {
        T Create(TParameter parameter);
    }
}
