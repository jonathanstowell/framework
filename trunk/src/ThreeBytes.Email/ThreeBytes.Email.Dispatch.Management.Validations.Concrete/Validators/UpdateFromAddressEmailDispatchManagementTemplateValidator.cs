using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Validators
{
    public class UpdateFromAddressEmailDispatchManagementTemplateValidator : AbstractValidator<EmailDispatchManagementTemplate>
    {
        public UpdateFromAddressEmailDispatchManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128.");
        }
    }
}