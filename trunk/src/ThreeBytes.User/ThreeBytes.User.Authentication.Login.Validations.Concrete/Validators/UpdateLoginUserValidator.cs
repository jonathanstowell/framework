using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UpdateLoginUserValidator : AbstractValidator<LoginUser>
    {
        public UpdateLoginUserValidator()
        {
            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool MustNotHaveDuplicateRoles(IList<LoginRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
