using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Validations.Concrete.Validators
{
    public class UpdateFromAddressEmailTemplateListTemplateValidator : AbstractValidator<EmailTemplateListTemplate>
    {
        public UpdateFromAddressEmailTemplateListTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128");
        }
    }
}