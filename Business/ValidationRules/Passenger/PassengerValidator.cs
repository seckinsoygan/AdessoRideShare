using Entities.Dtos.Passenger;
using FluentValidation;

namespace Business.ValidationRules.Passenger
{
	public class PassengerValidator : AbstractValidator<AddPassengerDto>
	{
		public PassengerValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.Name).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.Surname).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.Surname).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.FromWhere).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.FromTo).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
			RuleFor(x => x.Date).Must(ValidDate).WithMessage("'{PropertyName}' Entered date cannot be an old date");
		}
		private bool ValidDate(DateTime date)
		{
			return date >= DateTime.Today;
		}
	}
}
