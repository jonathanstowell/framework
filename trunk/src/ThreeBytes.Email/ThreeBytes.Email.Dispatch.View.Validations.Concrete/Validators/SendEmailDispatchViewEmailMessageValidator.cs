using FluentValidation;
using ThreeBytes.Email.Dispatch.View.Entities;

namespace ThreeBytes.Email.Dispatch.View.Validations.Concrete.Validators
{
    public class SendEmailDispatchViewEmailMessageValidator : AbstractValidator<EmailDispatchViewEmailMessage>
    {
        public SendEmailDispatchViewEmailMessageValidator()
        {
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

            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
