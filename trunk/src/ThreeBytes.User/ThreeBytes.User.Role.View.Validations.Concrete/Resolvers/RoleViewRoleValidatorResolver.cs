using System;
using FluentValidation;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Validations.Abstract;
using ThreeBytes.User.Role.View.Validations.Concrete.Validators;

namespace ThreeBytes.User.Role.View.Validations.Concrete.Resolvers
{
    public class RoleViewRoleValidatorResolver : IRoleViewRoleValidatorResolver
    {
        private readonly Func<CreateRoleViewRoleValidator> createRoleViewRoleValidator;
        private readonly Func<RenameRoleViewRoleValidator> renameRoleViewRoleValidator;

        public RoleViewRoleValidatorResolver(Func<CreateRoleViewRoleValidator> createRoleViewRoleValidator, Func<RenameRoleViewRoleValidator> renameRoleViewRoleValidator)
        {
            this.createRoleViewRoleValidator = createRoleViewRoleValidator;
            this.renameRoleViewRoleValidator = renameRoleViewRoleValidator;
        }

        public IValidator<RoleViewRole> CreateValidator()
        {
            return createRoleViewRoleValidator();
        }

        public IValidator<RoleViewRole> RenameValidator()
        {
            return renameRoleViewRoleValidator();
        }
    }
}
