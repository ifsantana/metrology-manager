using Faro.MetrologyManager.Domain.Entities.Base;
using Faro.MetrologyManager.Infra.CrossCutting.Specifications.Base.Interfaces;
using FluentValidation;

namespace Faro.MetrologyManager.Domain.Entities.Specifications.Entity.Interfaces
{
    public interface IEntitySpecifications<TEntity>
        : ISpecifications<TEntity>
        where TEntity : IEntity
    {
        void AddRuleIdIsRequired(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveCreationInfo(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveRowVersion(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveUpdateInfo(AbstractValidator<TEntity> validator);
    }
}
