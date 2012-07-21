using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Validators
{
    public class RenameEmailTemplateViewTemplateValidator : AbstractValidator<EmailTemplateViewTemplate>
    {
        public RenameEmailTemplateViewTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64");
        }
    }
}