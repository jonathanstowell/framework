using System;
using FluentValidation;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Validations.Abstract;
using ThreeBytes.User.Profile.View.Validations.Concrete.Validators;

namespace ThreeBytes.User.Profile.View.Validations.Concrete.Resolvers
{
    public class ProfileViewProfileValidatorResolver : IProfileViewProfileValidatorResolver
    {
        private readonly Func<CreateUserProfileViewProfileValidator> createUserProfileViewProfileValidator;
        private readonly Func<RenameUserProfileViewProfileValidator> renameUserProfileViewProfileValidator;
        private readonly Func<UpdateEmailUserProfileViewProfileValidator> updateEmailUserProfileViewProfileValidator;
        private readonly Func<LinkExternalProviderValidator> linkExternalProviderValidator;

        public ProfileViewProfileValidatorResolver(Func<CreateUserProfileViewProfileValidator> createUserProfileViewProfileValidator, Func<RenameUserProfileViewProfileValidator> renameUserProfileViewProfileValidator, Func<UpdateEmailUserProfileViewProfileValidator> updateEmailUserProfileViewProfileValidator, Func<LinkExternalProviderValidator> linkExternalProviderValidator)
        {
            this.createUserProfileViewProfileValidator = createUserProfileViewProfileValidator;
            this.renameUserProfileViewProfileValidator = renameUserProfileViewProfileValidator;
            this.updateEmailUserProfileViewProfileValidator = updateEmailUserProfileViewProfileValidator;
            this.linkExternalProviderValidator = linkExternalProviderValidator;
        }

        public IValidator<UserProfileViewProfile> CreateValidator()
        {
            return createUserProfileViewProfileValidator();
        }

        public IValidator<UserProfileViewProfile> UpdateEmailAddressValidator()
        {
            return updateEmailUserProfileViewProfileValidator();
        }

        public IValidator<UserProfileViewProfile> UpdateNameValidator()
        {
            return renameUserProfileViewProfileValidator();
        }

        public IValidator<UserProfileViewProfile> LinkExternalProviderValidator()
        {
            return linkExternalProviderValidator();
        }
    }
}
