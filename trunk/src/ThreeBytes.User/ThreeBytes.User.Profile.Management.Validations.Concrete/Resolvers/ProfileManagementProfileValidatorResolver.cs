using System;
using FluentValidation;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Validations.Abstract;
using ThreeBytes.User.Profile.Management.Validations.Concrete.Validators;

namespace ThreeBytes.User.Profile.Management.Validations.Concrete.Resolvers
{
    public class ProfileManagementProfileValidatorResolver : IProfileManagementProfileValidatorResolver
    {
        private readonly Func<CreateUserProfileManagementProfileValidator> createUserProfileManagementProfileValidator;
        private readonly Func<RenameUserProfileManagementProfileValidator> renameUserProfileManagementProfileValidator;
        private readonly Func<UpdateEmailUserProfileManagementProfileValidator> updateEmailUserProfileManagementProfileValidator;
        private readonly Func<LinkExternalProviderValidator> linkExternalProviderValidator;

        public ProfileManagementProfileValidatorResolver(Func<CreateUserProfileManagementProfileValidator> createUserProfileManagementProfileValidator, Func<RenameUserProfileManagementProfileValidator> renameUserProfileManagementProfileValidator, Func<UpdateEmailUserProfileManagementProfileValidator> updateEmailUserProfileManagementProfileValidator, Func<LinkExternalProviderValidator> linkExternalProviderValidator)
        {
            this.createUserProfileManagementProfileValidator = createUserProfileManagementProfileValidator;
            this.renameUserProfileManagementProfileValidator = renameUserProfileManagementProfileValidator;
            this.updateEmailUserProfileManagementProfileValidator = updateEmailUserProfileManagementProfileValidator;
            this.linkExternalProviderValidator = linkExternalProviderValidator;
        }

        public IValidator<UserProfileManagementProfile> CreateValidator()
        {
            return createUserProfileManagementProfileValidator();
        }

        public IValidator<UserProfileManagementProfile> UpdateEmailAddressValidator()
        {
            return updateEmailUserProfileManagementProfileValidator();
        }

        public IValidator<UserProfileManagementProfile> UpdateNameValidator()
        {
            return renameUserProfileManagementProfileValidator();
        }

        public IValidator<UserProfileManagementProfile> LinkExternalProviderValidator()
        {
            return linkExternalProviderValidator();
        }
    }
}
