using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Validations.Concrete.Validators
{
    public class DeleteEmailTemplateManagementTemplateValidator : AbstractValidator<EmailTemplateManagementTemplate>
    {
        public DeleteEmailTemplateManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");
        }
    }
}