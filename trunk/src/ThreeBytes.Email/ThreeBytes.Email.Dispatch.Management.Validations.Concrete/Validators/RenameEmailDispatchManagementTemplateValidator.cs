using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Validators
{
    public class RenameEmailDispatchManagementTemplateValidator : AbstractValidator<EmailDispatchManagementTemplate>
    {
        public RenameEmailDispatchManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64");
        }
    }
}
