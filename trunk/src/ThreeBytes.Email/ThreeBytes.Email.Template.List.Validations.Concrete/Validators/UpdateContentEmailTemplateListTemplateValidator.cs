using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Validations.Concrete.Validators
{
    public class UpdateContentEmailTemplateListTemplateValidator : AbstractValidator<EmailTemplateListTemplate>
    {
        public UpdateContentEmailTemplateListTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");
        }
    }
}