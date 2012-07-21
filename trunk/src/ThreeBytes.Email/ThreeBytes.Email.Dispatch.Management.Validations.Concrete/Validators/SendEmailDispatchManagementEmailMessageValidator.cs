using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Validators
{
    public class SendEmailDispatchManagementEmailMessageValidator : AbstractValidator<EmailDispatchManagementEmailMessage>
    {
        public SendEmailDispatchManagementEmailMessageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Template does not exist");

            RuleFor(x => x.ApplicationName)
                .NotEmpty()
                .Length(1, 20).WithMessage("'Application Name' must be a string with a maximum length of 20");

            RuleFor(x => x.From)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'From' must be a string with a maximum length of 128");

            RuleFor(x => x.To)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 128).WithMessage("'To' must be a string with a maximum length of 128");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .Length(1, 255).WithMessage("'Subject' must be a string with a maximum length of 255");

            RuleFor(x => x.Body)
                .NotEmpty();
        }
    }
}
