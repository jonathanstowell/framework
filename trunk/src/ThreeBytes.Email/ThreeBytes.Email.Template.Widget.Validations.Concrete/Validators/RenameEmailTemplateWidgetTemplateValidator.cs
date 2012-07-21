using FluentValidation;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Validations.Concrete.Validators
{
    public class RenameEmailTemplateWidgetTemplateValidator : AbstractValidator<EmailTemplateWidgetTemplate>
    {
        public RenameEmailTemplateWidgetTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64");
        }
    }
}