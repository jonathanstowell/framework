using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Validations.Concrete.Validators
{
    public class DeleteEmailTemplateListTemplateValidator : AbstractValidator<EmailTemplateListTemplate>
    {
        public DeleteEmailTemplateListTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");
        }
    }
}