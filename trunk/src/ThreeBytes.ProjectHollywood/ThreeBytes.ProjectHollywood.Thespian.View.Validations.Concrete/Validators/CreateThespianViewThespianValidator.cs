using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Validations.Concrete.Validators
{
    public class CreateThespianViewThespianValidator : AbstractValidator<ThespianViewThespian>
    {
        public CreateThespianViewThespianValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.Email).EmailAddress().Length(0, 320).WithMessage("'Email' must be a string with a maximum length of 320.");
            RuleFor(x => x.Location).Length(0, 200).WithMessage("'Location' must be a string with a maximum length of 200.");
            RuleFor(x => x.Twitter).Length(0, 20).WithMessage("'Twitter' must be a string with a maximum length of 20.");
            RuleFor(x => x.Facebook).Length(0, 255).WithMessage("'Facebook' must be a string with a maximum length of 255.");
            RuleFor(x => x.Spotlight).Length(0, 255).WithMessage("'Spotlight' must be a string with a maximum length of 255.");
            RuleFor(x => x.Imdb).Length(0, 255).WithMessage("'Imdb' must be a string with a maximum length of 255.");
        }
    }
}
