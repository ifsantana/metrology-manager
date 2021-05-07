using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Entities.Specifications.Entity.Interfaces;
using FluentValidation;

namespace Faro.MetrologyManager.Domain.Specifications.Points.Interfaces
{
    public interface IActualPointSpecification<IActualPoint> : IEntitySpecifications<IActualPoint>
        where IActualPoint : ActualPoint
    {
        void AddRuleNameIsRequired(AbstractValidator<IActualPoint> validator);
        void AddRuleNameMustHaveValidLength(AbstractValidator<IActualPoint> validator);
        void AddRuleXMustHaveValidValue(AbstractValidator<IActualPoint> validator);
        void AddRuleYMustHaveValidValue(AbstractValidator<IActualPoint> validator);
        void AddRuleZMustHaveValidValue(AbstractValidator<IActualPoint> validator);
    }
}