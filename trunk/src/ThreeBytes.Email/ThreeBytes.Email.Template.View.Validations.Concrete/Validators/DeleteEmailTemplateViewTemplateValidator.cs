using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Validators
{
    public class DeleteEmailTemplateViewTemplateValidator : AbstractValidator<EmailTemplateViewTemplate>
    {
        public DeleteEmailTemplateViewTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");
        }
    }
}