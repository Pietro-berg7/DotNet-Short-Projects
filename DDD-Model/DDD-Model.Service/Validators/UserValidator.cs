using DDD_Model.Domain.Entities;
using FluentValidation;

namespace DDD_Model.Service.Validators;
public class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
            .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name can only contain letters and spaces.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not in a valid format.");

        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Password is required.")
            .NotNull().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
            .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Password must contain at least one special character.");

    }
}
