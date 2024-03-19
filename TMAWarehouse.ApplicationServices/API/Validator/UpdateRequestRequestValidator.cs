using FluentValidation;
using TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest;

namespace TMAWarehouse.ApplicationServices.API.Validator;

internal class UpdateRequestRequestValidator : AbstractValidator<UpdateRequestRequest>
{
    public UpdateRequestRequestValidator()
    {
        this.RuleFor(x => x.RequestId).NotEmpty();
        this.RuleFor(x => x.Status).NotEmpty().Equals("confirmed").Equals("rejected");
    }
}
