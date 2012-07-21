using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Validations.Concrete.Validators
{
    public class RenameEmailTemplateManagementTemplateValidator : AbstractValidator<EmailTemplateManagementTemplate>
    {
        public RenameEmailTemplateManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64");
        }
    }
}