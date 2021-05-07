namespace Faro.MetrologyManager.Infra.CrossCutting.Validators.Base.Interfaces
{
    public interface IValidator<in T> : FluentValidation.IValidator<T>
    {

    }
}
