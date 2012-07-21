using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Validators
{
    public class UpdateContentEmailTemplateViewTemplateValidator : AbstractValidator<EmailTemplateViewTemplate>
    {
        public UpdateContentEmailTemplateViewTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");

            RuleFor(x => x.Body).NotEmpty();
        }
    }
}