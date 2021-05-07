namespace Faro.MetrologyManager.Infra.CrossCutting.Factories.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
