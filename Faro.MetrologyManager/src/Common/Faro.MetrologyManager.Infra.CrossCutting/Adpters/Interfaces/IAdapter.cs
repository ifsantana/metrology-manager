namespace Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces
{
    public interface IAdapter
    {
        TTo Adapt<TTo>(object from);
    }
}
