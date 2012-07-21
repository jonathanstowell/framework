using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Validations.Concrete.Validators
{
    public class UpdateContentEmailTemplateManagementTemplateValidator : AbstractValidator<EmailTemplateManagementTemplate>
    {
        public UpdateContentEmailTemplateManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");
            
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}