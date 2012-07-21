using System;
using FluentValidation;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Service.Abstract;

namespace ThreeBytes.Email.Template.View.Validations.Concrete.Validators
{
    public class CreateEmailViewManagementTemplateValidator : AbstractValidator<EmailTemplateViewTemplate>
    {
        public CreateEmailViewManagementTemplateValidator(IEmailTemplateViewTemplateService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 64).WithMessage("'Name' must be a string with a maximum length of 64")
                .Must((template, name) => service.UniqueTemplate(name, template.ApplicationName)).WithMessage("Cannot create duplicate Template");

            RuleFor(x => x.ApplicationName)
                .NotEmpty()
                .Length(1, 20).WithMessage("'Application Name' must be a string with a maximum length of 20");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");

            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
