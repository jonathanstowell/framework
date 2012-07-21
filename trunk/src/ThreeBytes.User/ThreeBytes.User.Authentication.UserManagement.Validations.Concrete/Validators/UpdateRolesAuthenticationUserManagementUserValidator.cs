using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class UpdateRolesAuthenticationUserManagementUserValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        public UpdateRolesAuthenticationUserManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool MustNotHaveDuplicateRoles(IList<AuthenticationUserManagementRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
