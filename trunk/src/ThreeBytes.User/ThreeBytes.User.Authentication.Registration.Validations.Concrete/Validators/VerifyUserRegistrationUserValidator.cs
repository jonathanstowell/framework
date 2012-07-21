using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators
{
    public class VerifyUserRegistrationUserValidator : AbstractValidator<RegistrationUser>
    {
        private readonly IRegistrationUserService service;

        public VerifyUserRegistrationUserValidator(IRegistrationUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.VerifiedCode)
                    .NotEmpty().WithMessage(Resources.Resources.RequiredVerifyCodeValidationMessage)
                    .Must((user, code) => VerifyCodeMustMatch(user.Id, code)).WithMessage(Resources.Resources.ValidVerifyCodeValidationMessage);
        }
        private bool VerifyCodeMustMatch(Guid id, Guid code)
        {
            return service.VerifyCodeMatches(id, code);
        }
    }
}
