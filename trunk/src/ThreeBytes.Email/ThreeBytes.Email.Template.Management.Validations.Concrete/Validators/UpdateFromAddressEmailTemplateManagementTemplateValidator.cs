using FluentValidation;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Validations.Concrete.Validators
{
    public class UpdateFromAddressEmailTemplateManagementTemplateValidator : AbstractValidator<EmailTemplateManagementTemplate>
    {
        public UpdateFromAddressEmailTemplateManagementTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128");
        }
    }
}