using System;
using FluentValidation;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Service.Abstract;

namespace ThreeBytes.Email.Template.Widget.Validations.Concrete.Validators
{
    public class CreateEmailWidgetManagementTemplateValidator : AbstractValidator<EmailTemplateWidgetTemplate>
    {
        public CreateEmailWidgetManagementTemplateValidator(IEmailTemplateWidgetTemplateService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64")
                .Must((template, name) => service.UniqueTemplate(name, template.ApplicationName)).WithMessage("Cannot create duplicate Template");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");
        }
    }
}
