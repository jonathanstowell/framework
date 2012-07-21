using System;
using System.Web;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Host.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Host.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Host.Validations.Concrete.Resolvers
{
    public class PersistImageValidatorResolver : IPersistImageValidatorResolver
    {
        private readonly Func<PersistImageValidator> createPersistedImageValidation;

        public PersistImageValidatorResolver(Func<PersistImageValidator> createPersistedImageValidation)
        {
            this.createPersistedImageValidation = createPersistedImageValidation;
        }

        public IValidator<HttpPostedFileBase> CreateValidator()
        {
            return createPersistedImageValidation();
        }
    }
}
