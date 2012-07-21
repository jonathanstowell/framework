using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators
{
    public class UpdateRolesLoginUserValidator : AbstractValidator<OAuthUser>
    {
        public UpdateRolesLoginUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool MustNotHaveDuplicateRoles(IList<OAuthRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
