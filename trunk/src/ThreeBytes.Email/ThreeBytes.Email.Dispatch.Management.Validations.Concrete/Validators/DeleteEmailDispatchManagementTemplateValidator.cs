using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Validators
{
    public class DeleteEmailDispatchManagementTemplateValidator : AbstractValidator<EmailDispatchManagementTemplate>
    {
        public DeleteEmailDispatchManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");
        }
    }
}