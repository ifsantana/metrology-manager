using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Entities.Validators.Entities;
using Faro.MetrologyManager.Domain.Specifications.Points.Interfaces;
using Faro.MetrologyManager.Domain.Validators.Points.Interfaces;

namespace Faro.MetrologyManager.Domain.Validators.Points
{
    public class IsActualPointValidToAddOrUpdateValidator : EntityValidator<ActualPoint>, IIsActualPointValidToAddOrUpdateValidator
    {
        public IsActualPointValidToAddOrUpdateValidator(IActualPointSpecification<ActualPoint> pointSpecification)
        {
            AddSpecificationsForEntityCreation(pointSpecification);

            pointSpecification.AddRuleNameIsRequired(this);
            pointSpecification.AddRuleNameMustHaveValidLength(this);
            pointSpecification.AddRuleXMustHaveValidValue(this);
            pointSpecification.AddRuleYMustHaveValidValue(this);
            pointSpecification.AddRuleZMustHaveValidValue(this);
        }
    }
}
