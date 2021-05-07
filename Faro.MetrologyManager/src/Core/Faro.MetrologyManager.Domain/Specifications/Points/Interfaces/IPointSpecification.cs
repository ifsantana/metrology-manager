using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Entities.Specifications.Entity.Interfaces;
using FluentValidation;

namespace Faro.MetrologyManager.Domain.Specifications.Points.Interfaces
{
    public interface IPointSpecification<IPoint> : IEntitySpecifications<IPoint>
        where IPoint : Point
    {
        void AddRuleNameIsRequired(AbstractValidator<IPoint> validator);
        void AddRuleNameMustHaveValidLength(AbstractValidator<IPoint> validator);
        void AddRuleXMustHaveValidValue(AbstractValidator<IPoint> validator);
        void AddRuleYMustHaveValidValue(AbstractValidator<IPoint> validator);
        void AddRuleZMustHaveValidValue(AbstractValidator<IPoint> validator);
    }
}
