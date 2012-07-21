using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Validators
{
    public class UpdateFromAddressEmailTemplateViewTemplateValidator : AbstractValidator<EmailTemplateViewTemplate>
    {
        public UpdateFromAddressEmailTemplateViewTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128");
        }
    }
}