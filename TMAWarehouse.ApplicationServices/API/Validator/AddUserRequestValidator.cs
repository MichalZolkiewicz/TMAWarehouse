using FluentValidation;
using TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;

namespace TMAWarehouse.ApplicationServices.API.Validator;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        this.RuleFor(x => x.Name).MaximumLength(250).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Surname).MaximumLength(250).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Login).MaximumLength(250).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(100).NotEqual("string");
    }
}
