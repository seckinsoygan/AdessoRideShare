using Entities.Dtos.Travel;
using FluentValidation;

namespace Business.ValidationRules.Travel
{
	public class TravelValidator : AbstractValidator<CreateTravelDto>
	{
		public TravelValidator()
		{
			RuleFor(x => x.FromWhere).NotEmpty().WithMessage("'{PropertyName}' cannot be empty");
			RuleFor(x => x.FromWhere).NotNull().WithMessage("'{PropertyName}' cannot be empty");
			RuleFor(x => x.FromWhere).MinimumLength(2).WithMessage("'{PropertyName}' Entered value must be greater than 2");
			RuleFor(x => x.FromTo).NotEmpty().WithMessage("'{PropertyName}' cannot be empty");
			RuleFor(x => x.FromTo).NotNull().WithMessage("'{PropertyName}' cannot be empty");
			RuleFor(x => x.FromTo).MinimumLength(2).WithMessage("'{PropertyName}' Entered value must be greater than 2");
			RuleFor(x => x.Date).Must(ValidDate).WithMessage("'{PropertyName}' Entered date cannot be an old date");
			RuleFor(x => x.Description).MinimumLength(5).WithMessage("'{PropertyName}' Entered value must be greater than 5");
			RuleFor(x => x.SeatCount).GreaterThan(1).WithMessage("'{PropertyName}' Entered value must be greater than 1");
		}
		private bool ValidDate(DateTime date)
		{
			return date >= DateTime.Today;
		}
	}
}
