using FluentValidation;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Validations.Concrete.Validators
{
    public class DeleteEmailTemplateWidgetTemplateValidator : AbstractValidator<EmailTemplateWidgetTemplate>
    {
        public DeleteEmailTemplateWidgetTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");
        }
    }
}