using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Entities.Specifications.Entity;
using Faro.MetrologyManager.Domain.Specifications.Points.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using FluentValidation;

namespace Faro.MetrologyManager.Domain.Specifications.Points
{
    public class PointSpecification<IPoint> : EntitySpecifications<IPoint>, IPointSpecification<IPoint>
        where IPoint : Point
    {
        private readonly IBus _bus;

        public PointSpecification(IBus bus)
        {
            _bus = bus;
        }

        public void AddRuleNameIsRequired(AbstractValidator<IPoint> validator)
        {
            validator.RuleFor(entity => entity.Name)
                .Must(q => !string.IsNullOrWhiteSpace(q)).WithMessage("name is required!");
        }

        public void AddRuleNameMustHaveValidLength(AbstractValidator<IPoint> validator)
        {
            validator.RuleFor(entity => entity.Name)
                .Must(q => q.Length <= 150).WithMessage("Name must have valid length - 150 chars")
                .When(q => !string.IsNullOrWhiteSpace(q.Name));
        }

        public void AddRuleXMustHaveValidValue(AbstractValidator<IPoint> validator)
        {
            validator.RuleFor(entity => entity.X)
                .GreaterThan(0).WithMessage("X must have valid value!");
        }

        public void AddRuleYMustHaveValidValue(AbstractValidator<IPoint> validator)
        {
            validator.RuleFor(entity => entity.Y)
                .GreaterThan(0).WithMessage("Y must have valid value!");
        }

        public void AddRuleZMustHaveValidValue(AbstractValidator<IPoint> validator)
        {
            validator.RuleFor(entity => entity.Z)
                .GreaterThan(0).WithMessage("Z must have valid value!");
        }
    }
}
