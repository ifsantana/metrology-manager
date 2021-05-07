using Faro.MetrologyManager.Domain.Entities.Base;
using Faro.MetrologyManager.Domain.Entities.Specifications.Entity.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Validators.Base;

namespace Faro.MetrologyManager.Domain.Entities.Validators.Entities
{
    public class EntityValidator<TEntity>
        : ValidatorBase<TEntity>
        where TEntity : IEntity
    {
        protected void AddSpecificationsForEntityCreation(IEntitySpecifications<TEntity> entitySpecifications)
        {
            entitySpecifications.AddRuleIdIsRequired(this);
            entitySpecifications.AddRuleMustHaveCreationInfo(this);
            entitySpecifications.AddRuleMustHaveRowVersion(this);
        }
        protected void AddSpecificationsForEntityUpdate(IEntitySpecifications<TEntity> entitySpecifications)
        {
            entitySpecifications.AddRuleMustHaveUpdateInfo(this);
        }
    }
}
