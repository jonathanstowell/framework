using FluentValidation;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Validations.Concrete.Validators
{
    public class RenameEmailTemplateListTemplateValidator : AbstractValidator<EmailTemplateListTemplate>
    {
        public RenameEmailTemplateListTemplateValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.Name).NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64");
        }
    }
}